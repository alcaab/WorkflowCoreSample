using System;
using System.Threading.Tasks;
using Contract.Domain.Interfaces;
using Contract.Domain.Models;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Contract.Workflow.Middleware
{
    public class WorkflowDocumentHistoryMiddleware : IWorkflowStepMiddleware
    {
        private readonly IWorkflowDocumentService _workflowDocumentService;
        private readonly ILogger<WorkflowDocumentHistoryMiddleware> _logger;

        public WorkflowDocumentHistoryMiddleware(IWorkflowDocumentService workflowDocumentService, ILogger<WorkflowDocumentHistoryMiddleware> logger)
        {
            _workflowDocumentService = workflowDocumentService;
            _logger = logger;
        }

        public async Task<ExecutionResult> HandleAsync(
            IStepExecutionContext context,
            IStepBody body,
            WorkflowStepDelegate next)
        {
            if (body is not ITrackableStep step)
                return await next();

            if (context.Workflow.Data is not IWorkflowDocumentParams documentParams) 
                return await next();

            var document = await _workflowDocumentService.GetWorkflowDocumentByRefAsync(
                documentParams.DocumentId, documentParams.DocumentType, context.Workflow.WorkflowDefinitionId,
                context.Workflow.Version);

            if (document == null)
                throw new Exception($"Document {documentParams.DocumentId } of type { documentParams.DocumentType } not found.");

            document.WorkflowId = context.Workflow.Id;

            var task = new DocumentTaskHistory
            {
                TaskId = context.ExecutionPointer.Id,
                CreateBy = "user",
                CreateDate = DateTime.UtcNow,
                TaskName = context.ExecutionPointer.StepName,
                TaskDescription = step.Description
            };

            if (context.ExecutionPointer.EventPublished)
                task.TaskDescription = step.TaskCompleteDescription;
                    
            document.TasksHistory.Add(task);

            await _workflowDocumentService.UpdateDocumentAsync(document);

            return await next();
        }
    }
}
