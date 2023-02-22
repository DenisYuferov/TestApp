using TestApp.Infrastructure.Repositories.Abstractions;

namespace TestApp.Infrastructure.UnitOfWorks.Abstractions
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        Task SaveAsync();
    }
}
