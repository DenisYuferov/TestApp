using Microsoft.EntityFrameworkCore;

using SharedCore.Infrastructure.Repositories.EntityFramework;

using TestApp.Domain.Abstraction.Postgre.Repositories;
using TestApp.Domain.Model.Postgre.Entities;
using TestApp.Infrastructure.Postgre.DbContexts;

namespace TestApp.Infrastructure.Postgre.Repositories
{
    public class AuthorRepository : RepositoryBase<Author, int>, IAuthorRepository
    {
        public AuthorRepository(PostgreDbContext context) : base(context)
        {

        }

        protected override IQueryable<Author> BaseQuery => 
            base.BaseQuery.Include(author => author.Books);
    }
}
