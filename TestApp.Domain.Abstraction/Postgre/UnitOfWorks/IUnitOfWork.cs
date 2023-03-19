using TestApp.Domain.Abstraction.Postgre.Repositories;

namespace TestApp.Domain.Abstraction.Postgre.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        ValueTask SaveAsync();
    }
}
