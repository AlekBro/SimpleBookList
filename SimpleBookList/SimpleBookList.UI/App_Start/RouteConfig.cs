namespace SimpleBookList.UI
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Route Configuration
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Register Routes
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{*catchall}",
                defaults: new { controller = "Books", action = "Index", id = UrlParameter.Optional });
        }
    }
}
