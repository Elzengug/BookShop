using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookShop.WebMVC.Startup))]
namespace BookShop.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
