using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoASP.Startup))]
namespace DemoASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
