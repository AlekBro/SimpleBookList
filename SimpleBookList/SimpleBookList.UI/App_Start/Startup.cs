using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(SimpleBookList.App_Start.Startup))]
 
namespace SimpleBookList.App_Start
{
    using Microsoft.AspNet.Identity;

    using BLL.Services;
    using BLL.Interfaces;

    public class Startup
    {
        // !!!
        // С помощью фабрики сервисов здесь создается сервис для работы с сервисами:
        IServiceCreator serviceCreator = new ServiceCreator();

        public void Configuration(IAppBuilder app)
        {
            // Потом сервис региструется контекстом OWIN:
            app.CreatePerOwinContext<IUserService>(CreateUserService);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        
        private IUserService CreateUserService()

        {
            return serviceCreator.CreateUserService("IdentityConnection");
        }
        
    }
}