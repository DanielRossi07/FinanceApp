using Finance.Domain.Entity;

namespace Finance.Domain.Interface
{
    public interface IInstallmentTransaction : ITransaction
    {
        public InstallmentPlan? InstallmentPlan { get; }
    }
}
