using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestniApp.Startup))]
namespace TestniApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
