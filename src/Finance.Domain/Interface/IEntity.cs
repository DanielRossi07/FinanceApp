namespace Finance.Domain.Interface
{
    public interface IEntity
    {
        Guid Id { get; }
        Guid UserId { get; }
        DateTime CreatedAt { get; }
        void Validate();
    }
}
