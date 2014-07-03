using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Specials.UI.Startup))]
namespace Specials.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
