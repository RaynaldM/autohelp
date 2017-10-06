using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoHelp.Startup))]
namespace AutoHelp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
