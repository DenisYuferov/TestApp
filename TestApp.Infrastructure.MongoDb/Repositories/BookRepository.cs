using Microsoft.Extensions.Options;

using MongoDB.Driver;

using TestApp.Domain.Model.MongoDb.Entities;
using TestApp.Infrastructure.MongoDb.Options;

namespace TestApp.Infrastructure.MongoDb.Repositories
{
    public class BookRepository
    {
        private readonly IMongoCollection<Book> _booksCollection;

        public BookRepository(IOptions<DatabaseOptions> options)
        {
            var mongoClient = new MongoClient(options.Value.Connection);

            var mongoDatabase = mongoClient.GetDatabase(options.Value.DbName);

            _booksCollection = mongoDatabase.GetCollection<Book>(options.Value.BooksCollection);
        }

        public async Task<List<Book>> GetAllAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book?> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Book book) =>
            await _booksCollection.InsertOneAsync(book);

        public async Task UpdateAsync(string id, Book book) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, book);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
