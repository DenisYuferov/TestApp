using TestApp.Domain.Abstraction.PostgreDb.Repositories;
using TestApp.Domain.Abstraction.PostgreDb.UnitOfWorks;
using TestApp.Infrastructure.PostgreDb.Contexts;

namespace TestApp.Infrastructure.PostgreDb.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        private TestAppDbContext _context;
        public IAuthorRepository AuthorRepository => _authorRepository;
        public IBookRepository BookRepository => _bookRepository;

        public UnitOfWork(
            IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            TestAppDbContext context)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async ValueTask SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
