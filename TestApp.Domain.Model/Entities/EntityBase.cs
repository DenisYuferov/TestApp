using TestApp.Domain.Model.Abstraction.Entities;

namespace TestApp.Domain.Model.Entities
{
    public class EntityBase<TId> : IEntity<TId>
        where TId : struct
    {
        public TId Id { get; set; }
    }
}
