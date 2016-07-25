using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using SimpleBookList.BLL.Interfaces;
using SimpleBookList.BLL.Services;

namespace SimpleBookList.WcfService
{
    public class WCFNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Injects the constructors of all DI-ed objects 
            //with a LinqToSQL implementation of IRepository
            //Bind<IRepository>().To<LinqToSQLRepository>();

            Bind<IBookListService>().To<BookListService>();
        }
    }
}