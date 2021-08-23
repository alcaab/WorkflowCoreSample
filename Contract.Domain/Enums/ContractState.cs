using System.ComponentModel;

namespace Contract.Domain.Enums
{
    public enum ContractState
    {
        [Description("Vorerfasst")] Preregistered,
        [Description("Vertragsprüfung")] InContractReview,
        [Description("Aktiv")] Active,
        [Description("Beendet")] Completed
    }
}
