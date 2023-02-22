using AutoMapper;
using TestApp.Domain.Commands.Authors;
using TestApp.Domain.Models.Authors;
using TestApp.Infrastructure.Entities;

namespace TestApp.Domain.Mappers
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper() 
        {
            CreateMap<AddAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();
            CreateMap<DeleteAuthorCommand, Author>();

            CreateMap<Author, AddAuthorModel>();
            CreateMap<Author, GetAuthorModel>();
            CreateMap<Author, GetAuthorWithBooksModel>();
        }
    }
}
