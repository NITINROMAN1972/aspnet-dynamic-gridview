using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dynamic_GridView.Startup))]
namespace Dynamic_GridView
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
