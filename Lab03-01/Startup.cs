using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab03_01.Startup))]
namespace Lab03_01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
