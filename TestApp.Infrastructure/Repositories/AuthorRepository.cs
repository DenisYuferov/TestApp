﻿using Microsoft.EntityFrameworkCore;
using TestApp.Infrastructure.Context;
using TestApp.Infrastructure.Entities;
using TestApp.Infrastructure.Repositories.Abstractions;

namespace TestApp.Infrastructure.Repositories
{
    public class AuthorRepository : RepositoryBase<Author, int>, IAuthorRepository
    {
        public AuthorRepository(TestAppInMemoryDbContext context) : base(context)
        {

        }

        protected override IQueryable<Author> BaseQuery => 
            base.BaseQuery.Include(author => author.Books);
    }
}