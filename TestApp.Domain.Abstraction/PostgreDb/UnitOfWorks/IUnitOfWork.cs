using TestApp.Domain.Abstraction.PostgreDb.Repositories;

namespace TestApp.Domain.Abstraction.PostgreDb.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        ValueTask SaveAsync();
    }
}
