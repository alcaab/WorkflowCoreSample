using Contract.Domain.Enums;
using Contract.Workflow.Steps.Base;
using WorkflowCore.Models;

namespace Contract.Workflow.Steps.Contract
{
    public class ReviewContractStep : WaitForStepBody<WorkflowParams<Domain.Models.Contract>, Domain.Models.Contract>
    {

        public ReviewContractStep()
        {
            Description = "The contract is in review state";
            TaskCompleteDescription = "The contract has been reviewed";
        }

        public override string EventName { get; set; } = nameof(ContractSteps.ReviewContract);

        protected override ExecutionResult OnComplete(CompleteTaskEventArgs<WorkflowParams<Domain.Models.Contract>, Domain.Models.Contract> args)
        {
            args.Model.Model.ApprovalState = args.EventData.ApprovalState;

            return ExecutionResult.Outcome(args.EventData.ApprovalState == ApprovalState.Approve? "Yes": "No");
        }
    }
}
