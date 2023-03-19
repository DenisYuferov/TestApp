using SharedCore.Domain.Abstraction.Repositories;

using TestApp.Domain.Model.Postgre.Entities;

namespace TestApp.Domain.Abstraction.Postgre.Repositories
{
    public interface IAuthorRepository : IRepository<Author, int>
    {

    }
}
