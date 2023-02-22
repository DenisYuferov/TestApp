using Microsoft.EntityFrameworkCore;
using TestApp.Infrastructure.DbContexts;
using TestApp.Infrastructure.Entities;
using TestApp.Infrastructure.Repositories.Abstractions;

namespace TestApp.Infrastructure.Repositories
{
    public class BookRepository : RepositoryBase<Book, int>, IBookRepository
    {
        public BookRepository(TestAppInMemoryDbContext context) : base(context)
        {

        }

        protected override IQueryable<Book> BaseQuery =>
            base.BaseQuery.Include(book => book.Author);
    }
}
