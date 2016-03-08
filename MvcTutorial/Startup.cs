using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcTutorial.Startup))]
namespace MvcTutorial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
