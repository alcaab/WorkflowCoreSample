using Contract.Workflow.Steps.Base;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Contract.Workflow.Steps.Contract
{
    public class PreregisterContractStep : TrackableStepBody
    {

        public PreregisterContractStep()
        {
            Description = "The contract has entered in pre-registered state";
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }


    }
}