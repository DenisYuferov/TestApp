using AutoMapper;
using TestApp.Domain.Model.Commands.Authors;
using TestApp.Domain.Model.Dtos.Authors;
using TestApp.Domain.Model.Entities;

namespace TestApp.Domain.Mappers
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper() 
        {
            CreateMap<AddAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();
            CreateMap<DeleteAuthorCommand, Author>();

            CreateMap<Author, AddAuthorDto>();
            CreateMap<Author, GetAuthorDto>();
            CreateMap<Author, GetAuthorWithBooksDto>();
        }
    }
}
