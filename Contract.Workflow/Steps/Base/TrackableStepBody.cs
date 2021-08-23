using Contract.Domain.Interfaces;
using WorkflowCore.Models;

namespace Contract.Workflow.Steps.Base
{
    public abstract class TrackableStepBody: StepBody, ITrackableStep
    {
        public string Description { get; set; }
        public string TaskCompleteDescription { get; set; }
    }
}
