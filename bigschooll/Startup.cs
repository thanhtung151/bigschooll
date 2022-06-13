using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bigschooll.Startup))]
namespace bigschooll
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
