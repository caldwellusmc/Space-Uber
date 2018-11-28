using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpaceUber.WebMVC.Startup))]
namespace SpaceUber.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
