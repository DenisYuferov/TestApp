using AutoMapper;
using TestApp.Domain.Model.CQRS.Commands.Authors;
using TestApp.Domain.Model.CQRS.Dtos.Authors;
using TestApp.Domain.Model.PostgreDb.Entities;

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
