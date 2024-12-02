namespace Finance.Domain.SeedWork
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(Guid userId) : base(userId) { }
    }
}
