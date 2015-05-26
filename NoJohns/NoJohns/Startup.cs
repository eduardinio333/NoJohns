using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NoJohns.Startup))]
namespace NoJohns
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
