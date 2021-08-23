using System;
using WorkflowCore.Interface;

namespace Contract.Workflow.Steps.Base
{
    public class CompleteTaskEventArgs<TModel, TEventData> : EventArgs
    {

        public IStepExecutionContext Context { get; set; }
        public TModel Model { get; set; }
        public TEventData EventData { get; set; }
    }
}