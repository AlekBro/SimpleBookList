// -----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SimpleBookList.WebAPI
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Http;

    using BLL.Infrastructure;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMappings();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
