﻿using TestApp.Domain.Abstraction.Postgre.Repositories;
using TestApp.Domain.Abstraction.Postgre.UnitOfWorks;
using TestApp.Infrastructure.Postgre.DbContexts;

namespace TestApp.Infrastructure.Postgre.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        private PostgreDbContext _context;
        public IAuthorRepository AuthorRepository => _authorRepository;
        public IBookRepository BookRepository => _bookRepository;

        public UnitOfWork(
            IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            PostgreDbContext context)
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