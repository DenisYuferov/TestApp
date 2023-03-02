using AutoMapper;
using TestApp.Domain.Model.Commands.Books;
using TestApp.Domain.Model.Entities;
using TestApp.Domain.Model.Views.Books;

namespace TestApp.Domain.Mappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<AddBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<DeleteBookCommand, Book>();

            CreateMap<Book, AddBookView>();
            CreateMap<Book, GetBookView>();
            CreateMap<Book, GetBookWithAuthorView>()
                .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(book => $"{book.Author!.FirstName} {book.Author.LastName}"));
        }
    }
}
