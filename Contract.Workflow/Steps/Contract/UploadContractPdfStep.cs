using Contract.Workflow.Steps.Base;
using WorkflowCore.Models;

namespace Contract.Workflow.Steps.Contract
{
    public class UploadContractPdfStep : WaitForStepBody<WorkflowParams<Domain.Models.Contract>,Domain.Models.Contract> 
    {

        public UploadContractPdfStep()
        {
            Description = "PDF document waiting to be uploaded";
            TaskCompleteDescription = "PDF documento has been uploaded";
        }

        public override string EventName { get;set; } = nameof(ContractSteps.UploadContractPdf);

        protected override ExecutionResult OnComplete(CompleteTaskEventArgs<WorkflowParams<Domain.Models.Contract>, Domain.Models.Contract> args)
        {
            return ExecutionResult.Next();
        }
    }
}
