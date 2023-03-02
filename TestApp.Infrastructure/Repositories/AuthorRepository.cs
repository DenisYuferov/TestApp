using Microsoft.EntityFrameworkCore;
using TestApp.Domain.Abstraction.Repositories;
using TestApp.Domain.Model.Entities;
using TestApp.Infrastructure.DbContexts;

namespace TestApp.Infrastructure.Repositories
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
