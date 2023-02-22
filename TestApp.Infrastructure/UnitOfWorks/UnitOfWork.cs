using TestApp.Infrastructure.Context;
using TestApp.Infrastructure.Repositories.Abstractions;
using TestApp.Infrastructure.UnitOfWorks.Abstractions;

namespace TestApp.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        private TestAppInMemoryDbContext _context;
        public IAuthorRepository AuthorRepository => _authorRepository;
        public IBookRepository BookRepository => _bookRepository;

        public UnitOfWork(
            IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            TestAppInMemoryDbContext context)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
