using Finance.Domain.Entity;

namespace Finance.Domain.Interface
{
    public interface ISplitTransaction : ITransaction
    {
        public List<SplitTransaction> SplitTransactions { get; }
    }
}
