using Microsoft.Owin;
using Owin;
using Radiostr.Web;

[assembly: OwinStartup("Radiostr.Web.Startup", typeof(Startup))]

namespace Radiostr.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
