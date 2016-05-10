using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace SimpleBookList.BLL.Infrastructure
{
    //using DAL.Entities;
    //using Models;
    public static class AutoMapperConfig
    {
        public static MapperConfiguration Configuration { get; private set; }


        public static void RegisterMappings()
        {
            /*
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<BookViewModel, Book>());
            
            IMapper mapper  = config.CreateMapper();
            */

            Configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            //Mapper.CreateMap<Author, AuthorViewModel>();
        }
    }
}