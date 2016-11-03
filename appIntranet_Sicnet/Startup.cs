using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(appIntranet_Sicnet.Startup))]
namespace appIntranet_Sicnet
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            //ConfigureAuth(app);
        }
    }
}
