// -----------------------------------------------------------------------
// <copyright file="CustomAuthorizeAttribute.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.UI.Utils
{
    using Models;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    /// <summary>
    /// Custom authorize attribute
    /// </summary>
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // The user is not authenticated
                base.HandleUnauthorizedRequest(filterContext);
            }
            else if (!this.Roles.Split(',').Any(filterContext.HttpContext.User.IsInRole))
            {
                // The user is not in any of the listed roles => 
                // show the unauthorized view
                /*
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/_Unauthorized.cshtml"
                };
                */
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    throw new NotEnuffRightsException("NotEnuffRights");
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Unauthorized" }));
                }
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}