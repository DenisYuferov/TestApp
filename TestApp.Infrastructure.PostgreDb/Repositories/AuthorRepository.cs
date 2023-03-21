using Microsoft.EntityFrameworkCore;

using SharedCore.Infrastructure.Repositories.EntityFramework;

using TestApp.Domain.Abstraction.PostgreDb.Repositories;
using TestApp.Domain.Model.PostgreDb.Entities;
using TestApp.Infrastructure.PostgreDb.Contexts;

namespace TestApp.Infrastructure.PostgreDb.Repositories
{
    public class AuthorRepository : RepositoryBase<Author, int>, IAuthorRepository
    {
        public AuthorRepository(TestAppDbContext context) : base(context)
        {

        }

        protected override IQueryable<Author> BaseQuery =>
            base.BaseQuery.Include(author => author.Books);
    }
}
