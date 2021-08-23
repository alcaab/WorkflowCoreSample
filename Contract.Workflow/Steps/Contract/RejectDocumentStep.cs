using Contract.Workflow.Steps.Base;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Contract.Workflow.Steps.Contract
{
    public class RejectContractStep : TrackableStepBody
    {

        public RejectContractStep()
        {
            Description = "The contract has been rejected";
        }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            //Here actions required to change the status of the contract to "Vorerfasst"
            return ExecutionResult.Next();
        }
    }
}