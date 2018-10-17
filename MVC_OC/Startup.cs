using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_OC.Startup))]
namespace MVC_OC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
