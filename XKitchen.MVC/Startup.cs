using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XKitchen.MVC.Startup))]
namespace XKitchen.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
