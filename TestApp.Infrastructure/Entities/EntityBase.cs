using TestApp.Infrastructure.Entities.Abstractions;

namespace TestApp.Infrastructure.Entities
{
    public class EntityBase<TId> : IEntity<TId>
        where TId : struct
    {
        public TId Id { get; set; }
    }
}
