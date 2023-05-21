namespace TestApp.Infrastructure.PostgreDb.Options
{
    public class DatabaseOptions
    {
        public const string SectionName = "Postgre";
        public string? Connection { get; set; }
    }
}