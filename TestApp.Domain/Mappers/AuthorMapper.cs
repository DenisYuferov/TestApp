using AutoMapper;
using TestApp.Domain.Model.Commands.Authors;
using TestApp.Domain.Model.Entities;
using TestApp.Domain.Model.Views.Authors;

namespace TestApp.Domain.Mappers
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper() 
        {
            CreateMap<AddAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();
            CreateMap<DeleteAuthorCommand, Author>();

            CreateMap<Author, AddAuthorView>();
            CreateMap<Author, GetAuthorView>();
            CreateMap<Author, GetAuthorWithBooksView>();
        }
    }
}
