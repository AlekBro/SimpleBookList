// -----------------------------------------------------------------------
// <copyright file="NinjectDependencyResolver.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.UI.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using BLL.Interfaces;
    using BLL.Services;
    using Ninject;

    /// <summary>
    /// Dependency mapper class
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// Property for Kernel class
        /// </summary>
        private IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyResolver" /> class.
        /// </summary>
        /// <param name="kernel">IKernel interface</param>
        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;

            this.AddBindings();
        }

        /// <summary>
        /// Try get service
        /// </summary>
        /// <param name="serviceType">Service Type</param>
        /// <returns>service object</returns>
        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        /// <summary>
        /// Get all services
        /// </summary>
        /// <param name="serviceType">Service Type</param>
        /// <returns>all service objects</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }

        /// <summary>
        /// Dependency injection for EventService
        /// </summary>
        private void AddBindings()
        {
            this.kernel.Bind<IBookListService>().To<BookListService>();
        }
    }
}