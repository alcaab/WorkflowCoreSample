using Contract.Workflow.Steps.Base;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Contract.Workflow.Steps.Contract
{
    public class ApproveContractStep : TrackableStepBody
    {

        public ApproveContractStep()
        {
            Description = "The contract has been approved";
        }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            //Here actions required to change the status of the contract to "Aktiv"
            return ExecutionResult.Next();
        }
    }
}