// -----------------------------------------------------------------------
// <copyright file="NinjectWebCommon.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SimpleBookList.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SimpleBookList.UI.App_Start.NinjectWebCommon), "Stop")]

namespace SimpleBookList.UI.App_Start
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    using BLL.Infrastructure;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;
    using Utils;

    /// <summary>
    /// Ninject Configuration
    /// </summary>
    public static class NinjectWebCommon 
    {
        /// <summary>
        /// Bootstrapper property
        /// </summary>
        private static readonly Bootstrapper BootstrapperProperty = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            BootstrapperProperty.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            BootstrapperProperty.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            // Establish a connection string
            var modules = new INinjectModule[] { new ServiceModule("DefaultConnection") };

            var kernel = new StandardKernel(modules);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // We register our dependency resolver.
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }        
    }
}
