using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleBookList.UI.Startup))]
namespace SimpleBookList.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
