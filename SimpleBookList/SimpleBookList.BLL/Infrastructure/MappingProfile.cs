using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleBookList.BLL.Infrastructure
{
    using AutoMapper;

    using DAL;
    using Models;
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Book, BookViewModel>();
            CreateMap<AuthorViewModel, Author>();
            CreateMap<BookViewModel, Book>();
        }
    }
}
