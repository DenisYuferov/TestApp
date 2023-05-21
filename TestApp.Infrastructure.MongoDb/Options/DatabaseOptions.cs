namespace TestApp.Infrastructure.MongoDb.Options
{
    public class DatabaseOptions
    {
        public const string SectionName = "Mongo";
        public string? Connection { get; set; }

        public string? DbName { get; set; }

        public string? BooksCollection { get; set; }
    }
}