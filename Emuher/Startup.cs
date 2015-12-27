using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Emuher.Startup))]
namespace Emuher
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
