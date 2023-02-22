using TestApp.Domain.Models.Books;

namespace TestApp.Domain.Models.Authors
{
    public class GetAuthorWithBooksModel
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }

        public List<GetBookModel>? Books { get; set; }
    }
}