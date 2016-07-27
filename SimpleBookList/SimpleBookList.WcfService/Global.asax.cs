namespace SimpleBookList.WcfService
{
    using Ninject;
    using Ninject.Extensions.Wcf;
    using Ninject.Modules;
    using Ninject.Web.Common;
    using SimpleBookList.BLL.Infrastructure;

    public class Global : NinjectHttpApplication
    {

        // http://stackoverflow.com/questions/32167565/global-asaxs-application-start-method-doesnt-get-called
        protected override void OnApplicationStarted()
        {
            AutoMapperConfig.RegisterMappings();
        }
        
        protected override IKernel CreateKernel()
        {
            // Establish a connection string
            var modules = new INinjectModule[] { new ServiceModule("DefaultConnection"), new WCFNinjectModule() };
            var kernel = new StandardKernel(modules);

            return kernel;
        }
    }
}