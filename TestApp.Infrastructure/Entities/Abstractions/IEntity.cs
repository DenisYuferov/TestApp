namespace TestApp.Infrastructure.Entities.Abstractions
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
