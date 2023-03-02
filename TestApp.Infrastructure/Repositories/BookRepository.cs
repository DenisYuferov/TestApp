using Microsoft.EntityFrameworkCore;
using TestApp.Domain.Abstraction.Repositories;
using TestApp.Domain.Model.Entities;
using TestApp.Infrastructure.DbContexts;

namespace TestApp.Infrastructure.Repositories
{
    public class BookRepository : RepositoryBase<Book, int>, IBookRepository
    {
        public BookRepository(PostgreDbContext context) : base(context)
        {

        }

        protected override IQueryable<Book> BaseQuery =>
            base.BaseQuery.Include(book => book.Author);
    }
}
