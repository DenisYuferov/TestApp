namespace TestApp.Domain.Model.CQRS.Dtos.Books
{
    public class GetBookWithAuthorDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Cost { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorFullName { get; set; }
    }
}