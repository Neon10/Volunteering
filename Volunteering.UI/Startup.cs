using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Volunteering.Domain.Dtos;
using static Volunteering.Service.Startup;


[assembly: OwinStartup(typeof(Volunteering.UI.Startup))]

namespace Volunteering.UI
{
    public partial class Startup
    {

        //TODO Refactor OWIN startup
        public void Configuration(IAppBuilder app)
        {
            // ConfigureAuth(app);

            OwinInit(app);
            //app.SetDefaultSignInAsAuthenticationType(DefaultAuthenticationTypes.ApplicationCookie);


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            AutoMapper.Configure();

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "188939881791663",
            //   appSecret: "d5602158adb6d1f40ecb56ae25819ebb");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }


    }
}
