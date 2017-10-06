using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace AutoHelp
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Autoriser l’application à utiliser un cookie pour stocker des informations pour l’utilisateur connecté
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Account/Login")
            //});
            //// Use a cookie to temporarily store information about a user logging in with a third party login provider
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
     
        }
    }
}