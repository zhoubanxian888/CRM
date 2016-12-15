using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRM.WebApp.Startup))]
namespace CRM.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
