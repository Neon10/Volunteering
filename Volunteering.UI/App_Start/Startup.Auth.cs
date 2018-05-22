using Owin;
using Volunteering.Service;

namespace Volunteering.UI
{
    public partial class Startup
    {


        public void ConfigureAuth(IAppBuilder app)
        {
            var s = new AppService();

            // app.CreatePerOwinContext(s.aaa());

        }


    }
}
