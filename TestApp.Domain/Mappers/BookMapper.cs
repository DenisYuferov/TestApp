using AutoMapper;
using TestApp.Domain.Commands.Books;
using TestApp.Domain.Models.Books;
using TestApp.Infrastructure.Entities;

namespace TestApp.Domain.Mappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<AddBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<DeleteBookCommand, Book>();

            CreateMap<Book, AddBookModel>();
            CreateMap<Book, GetBookModel>();
            CreateMap<Book, GetBookWithAuthorModel>()
                .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(book => $"{book.Author!.FirstName} {book.Author.LastName}"));
        }
    }
}
