// -----------------------------------------------------------------------
// <copyright file="WCFNinjectModule.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.WcfService
{
    using Ninject.Modules;
    using BLL.Interfaces;
    using BLL.Services;


    public class WCFNinjectModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IBookListService>().To<BookListService>();
        }
    }
}