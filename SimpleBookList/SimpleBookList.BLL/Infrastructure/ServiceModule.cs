// -----------------------------------------------------------------------
// <copyright file="ServiceModule.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.BLL.Infrastructure
{
    using DAL.Interfaces;
    using DAL.Repositories;
    using Interfaces;
    using Ninject.Modules;
    using Services;
    /// <summary>
    /// Dependency injection for UnitOfWork
    /// </summary>
    public class ServiceModule : NinjectModule
    {
        /// <summary>
        /// String with settings for connection to the Database
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceModule" /> class.
        /// </summary>
        /// <param name="connectionString">String with settings for connection to the Database</param>
        public ServiceModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Organize mapping dependencies
        /// </summary>
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(this.connectionString);

            Bind<IUserService>().To<UserService>().WithConstructorArgument(this.connectionString);
        }
    }
}
