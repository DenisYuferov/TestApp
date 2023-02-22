namespace TestApp.Domain.Models.Books
{
    public class GetBookWithAuthorModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public double Cost { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorFullName { get; set; }
    }
}