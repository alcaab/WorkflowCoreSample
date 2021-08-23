using System;
using Contract.Domain.Interfaces;
using Contract.Services;
using Contract.Workflow.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

namespace Contract.Workflow
{
    public static class ServiceCollectionExtensions
    {
        public static void AddContractWorkflow(this IServiceCollection services, string connectionString)
        {
            services.AddWorkflow(x => x.UseSqlServer(connectionString, true, true));

            services.AddWorkflowStepMiddleware<WorkflowDocumentHistoryMiddleware>();

            services.AddWorkflowMiddleware<WorkflowDocumentMiddleware>();

            services.AddTransient<IWorkflowMiddlewareErrorHandler, WorkflowDocumentExceptionHandler>();

            services.AddTransient<IWorkflowDocumentService, WorkflowDocumentService>();
        }

        public static IApplicationBuilder UseContractWorkflow(this IApplicationBuilder app)
        {
            var host = app.ApplicationServices.GetService<IWorkflowHost>();
            if (host == null)
                throw new NullReferenceException(nameof(IWorkflowHost));

            host.RegisterWorkflow<ContractWorkflow, WorkflowParams<Contract.Domain.Models.Contract>>();

            host.Start();

            return app;
        }
    }
}
