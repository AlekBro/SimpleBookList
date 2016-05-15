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
            CreateMap<Author, AuthorViewModel>().ForMember(x => x.Name, opt => opt.Ignore())
                .ForMember(x => x.BooksNumber, opt => opt.MapFrom(x => x.Books.Count));

            CreateMap<Book, BookViewModel>()
                .ForMember(x => x.Authors, opt => opt.MapFrom(y => y.Authors));

             //.ForMember(x => x.Authors, opt => opt.Ignore()); 

            CreateMap<AuthorViewModel, Author>();

            /*
            Mapper.CreateMap<GoodEntity, GoodDTO>()
  .ForMember(dto => dto.providers, opt => opt.MapFrom(x => x.GoodsAndProviders.Select(y => y.Providers).ToList()));
  */
            //().ForMember(x => x.Books, opt => opt.Ignore());


            CreateMap<BookViewModel, Book>().ForMember(model => model.Authors, opt => opt.MapFrom(x => x.Authors));
            //.ForMember(dto => dto.Authors, opt => opt.MapFrom(x => x.Authors.Select(y => y.).ToList()));
            //.ForMember(x => x.Authors, opt => opt.Ignore()); ;
        }
    }
}
