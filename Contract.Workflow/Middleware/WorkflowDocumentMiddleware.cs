using System;
using System.Threading.Tasks;
using Contract.Domain.Interfaces;
using Contract.Domain.Models;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Contract.Workflow.Middleware
{
    public class WorkflowDocumentMiddleware : IWorkflowMiddleware
    {
        private readonly IWorkflowDocumentService _workflowDocumentService;
        private readonly ILogger<WorkflowDocumentHistoryMiddleware> _logger;

        public WorkflowDocumentMiddleware(IWorkflowDocumentService workflowDocumentService, ILogger<WorkflowDocumentHistoryMiddleware> logger)
        {
            _workflowDocumentService = workflowDocumentService;
            _logger = logger;
        }

        public WorkflowMiddlewarePhase Phase => WorkflowMiddlewarePhase.PreWorkflow;

        public async Task HandleAsync(WorkflowInstance workflow, WorkflowDelegate next)
        {

            if (workflow.Data is IWorkflowDocumentParams documentParams)
            {

                var document = await _workflowDocumentService.GetWorkflowDocumentByRefAsync(
                    documentParams.DocumentId, documentParams.DocumentType, workflow.WorkflowDefinitionId,
                    workflow.Version) ?? new WorkflowDocument
                    {
                        Id = Guid.NewGuid().ToString(),
                        DocumentType = documentParams.DocumentType,
                        DocumentRefId = documentParams.DocumentId,
                        WorkflowDefinitionId = workflow.WorkflowDefinitionId,
                        Version = workflow.Version,
                        IsNew = true
                    };

                if (!document.IsNew)
                    throw new Exception($"Document {document.Id } of type { documentParams.DocumentType } already registered with instance {document.Id}.");

                await _workflowDocumentService.AddDocumentAsync(document);
                
            }

            await next();
        }
    }
}
