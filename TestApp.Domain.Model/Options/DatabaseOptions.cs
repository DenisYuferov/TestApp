namespace TestApp.Domain.Model.Options
{
    public class DatabaseOptions
    {
        public const string Database = "Database";

        public bool? InMemory { get; set; }
        public string? Connection { get; set; }
    }
}