namespace Contract.Workflow.Steps.Base
{
    public class StepDefinition
    {
        public StepDefinition(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public StepDefinition(string id) : this(id, id)
        {
            Id = id;
        }

        public string Id { get; }

        public string Name { get; }
    }
}