namespace TestApp.Domain.Model.CQRS.Dtos.Authors
{
    public class GetAuthorDto
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}