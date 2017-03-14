using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eMat.Web.Startup))]
namespace eMat.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
