using Finance.Domain.Entity;

namespace Finance.Domain.Interface
{
    public interface IRecurrentTransaction : ITransaction
    {
        public RecurrentTransaction? RecurrentTransaction { get; }
    }
}
