using SharedCore.Domain.Abstraction.Repositories;

using TestApp.Domain.Model.PostgreDb.Entities;

namespace TestApp.Domain.Abstraction.PostgreDb.Repositories
{
    public interface IAuthorRepository : IRepository<Author, int>
    {

    }
}
