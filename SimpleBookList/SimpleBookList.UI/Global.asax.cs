namespace SimpleBookList.UI
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using BLL.Infrastructure;

    /// <summary>
    /// Main class for Application
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Application Start
        /// </summary>
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMappings();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
