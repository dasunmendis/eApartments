using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlobeFA.Web.Startup))]
namespace GlobeFA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
