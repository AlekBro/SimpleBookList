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
            CreateMap<Author, AuthorViewModel>()
                .ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.BooksNumber, opt => opt.MapFrom(x => x.Books.Count));

            CreateMap<Book, BookViewModel>()
                .ForMember(x => x.Authors, opt => opt.MapFrom(y => y.Authors));


            CreateMap<AuthorViewModel, Author>();


            CreateMap<BookViewModel, Book>()
                .ForMember(model => model.Authors, opt => opt.MapFrom(x => x.Authors));

        }
    }
}
