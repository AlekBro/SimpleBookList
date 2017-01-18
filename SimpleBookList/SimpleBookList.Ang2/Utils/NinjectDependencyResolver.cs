// -----------------------------------------------------------------------
// <copyright file="NinjectDependencyResolver.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Ang2.Utils
{
    using System.Web.Http.Dependencies;

    using Ninject;
    
    // This class is the resolver, but it is also the global scope
    // so we derive from NinjectScope.
    // http://www.peterprovost.org/blog/2012/06/19/adding-ninject-to-web-api
    /// <summary>
    /// 
    /// </summary>
    public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Http.Dependencies.IDependencyResolver
    {
        IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }
}