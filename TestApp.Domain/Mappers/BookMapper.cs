using AutoMapper;
using TestApp.Domain.Model.CQRS.Dtos.Books;
using TestApp.Domain.Model.CQRS.Commands.Books;
using TestApp.Domain.Model.Postgre.Entities;

namespace TestApp.Domain.Mappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<AddBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<DeleteBookCommand, Book>();

            CreateMap<Book, AddBookDto>();
            CreateMap<Book, GetBookDto>();
            CreateMap<Book, GetBookWithAuthorDto>()
                .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(book => $"{book.Author!.FirstName} {book.Author.LastName}"));
        }
    }
}
