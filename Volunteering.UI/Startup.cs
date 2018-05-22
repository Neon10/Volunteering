using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Volunteering.UI.Startup))]

namespace Volunteering.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
