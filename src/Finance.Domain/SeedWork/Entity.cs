namespace Finance.Domain.SeedWork
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        protected Entity(Guid userId)
        {
            UserId = userId;
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}
