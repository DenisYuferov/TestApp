namespace TestApp.Domain.Model.CQRS.Dtos.Books
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public double Cost { get; set; }
    }
}