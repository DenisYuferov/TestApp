using Microsoft.EntityFrameworkCore;

using SharedCore.Infrastructure.Repositories.EntityFramework;

using TestApp.Domain.Abstraction.PostgreDb.Repositories;
using TestApp.Domain.Model.PostgreDb.Entities;
using TestApp.Infrastructure.PostgreDb.Contexts;

namespace TestApp.Infrastructure.PostgreDb.Repositories
{
    public class BookRepository : RepositoryBase<Book, int>, IBookRepository
    {
        public BookRepository(TestAppDbContext context) : base(context)
        {

        }

        protected override IQueryable<Book> BaseQuery =>
            base.BaseQuery.Include(book => book.Author);
    }
}
