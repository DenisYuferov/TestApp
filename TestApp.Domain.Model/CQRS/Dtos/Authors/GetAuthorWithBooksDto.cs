using TestApp.Domain.Model.CQRS.Dtos.Books;

namespace TestApp.Domain.Model.CQRS.Dtos.Authors
{
    public class GetAuthorWithBooksDto
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }

        public List<GetBookDto>? Books { get; set; }
    }
}