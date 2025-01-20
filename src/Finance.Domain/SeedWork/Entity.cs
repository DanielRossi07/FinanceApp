using Finance.Domain.Interface;

namespace Finance.Domain.SeedWork
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected Entity(Guid userId)
        {
            UserId = userId;
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        public abstract void Validate();
    }
}
