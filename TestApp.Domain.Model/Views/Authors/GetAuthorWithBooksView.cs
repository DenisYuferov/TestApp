using TestApp.Domain.Model.Views.Books;

namespace TestApp.Domain.Model.Views.Authors
{
    public class GetAuthorWithBooksView
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }

        public List<GetBookView>? Books { get; set; }
    }
}