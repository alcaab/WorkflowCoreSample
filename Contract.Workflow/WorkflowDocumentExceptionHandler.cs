using System;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Contract.Workflow
{
    public class WorkflowDocumentExceptionHandler : IWorkflowMiddlewareErrorHandler
    {
        public WorkflowDocumentExceptionHandler()
        {
            
        }
        public Task HandleAsync(Exception ex)
        {
            return Task.CompletedTask;
        }
    }
}