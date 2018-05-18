using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Volunteering.Web.Startup))]
namespace Volunteering.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
