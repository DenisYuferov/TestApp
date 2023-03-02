using TestApp.Domain.Abstraction.Repositories;

namespace TestApp.Domain.Abstraction.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        ValueTask SaveAsync();
    }
}
