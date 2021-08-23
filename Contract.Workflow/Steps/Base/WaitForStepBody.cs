using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Contract.Workflow.Steps.Base
{
    public abstract class WaitForStepBody<TModel,TEventData> : TrackableStepBody
    {
        public virtual string EventKey { get; set; }

        public virtual string EventName { get; set; }

        public virtual DateTime? EffectiveDate { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            if (!context.ExecutionPointer.EventPublished)
            {
                OnCreate(context);

                var eventKey = EventKey;
                if (string.IsNullOrEmpty(eventKey))
                    eventKey = context.Workflow.Id;

                return ExecutionResult.WaitForEvent(EventName, eventKey, EffectiveDate ?? DateTime.Now);
            }
            
            var result = OnComplete(new CompleteTaskEventArgs<TModel, TEventData>
            {
                Context = context,
                Model = (TModel) context.Workflow.Data,
                EventData = (TEventData) context.ExecutionPointer.EventData
            });

            return result;
        }

        protected virtual void OnCreate(IStepExecutionContext context)
        {
        }

        protected abstract ExecutionResult OnComplete(CompleteTaskEventArgs<TModel, TEventData> args);
    }

    public abstract class WaitForStepBody<TModel> : WaitForStepBody<TModel, TModel>
    {
    }
}
