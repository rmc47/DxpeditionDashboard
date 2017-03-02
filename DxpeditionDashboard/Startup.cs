using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DxpeditionDashboard.Startup))]
namespace DxpeditionDashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
