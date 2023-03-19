using Microsoft.EntityFrameworkCore;

using SharedCore.Infrastructure.Repositories.EntityFramework;

using TestApp.Domain.Abstraction.Postgre.Repositories;
using TestApp.Domain.Model.Postgre.Entities;
using TestApp.Infrastructure.Postgre.DbContexts;

namespace TestApp.Infrastructure.Postgre.Repositories
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
