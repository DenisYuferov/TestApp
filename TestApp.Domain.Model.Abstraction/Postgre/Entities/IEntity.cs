namespace TestApp.Domain.Model.Abstraction.Postgre.Entities
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
