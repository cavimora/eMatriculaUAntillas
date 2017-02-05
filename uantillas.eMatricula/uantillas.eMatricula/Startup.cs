using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(uantillas.eMatricula.Startup))]
namespace uantillas.eMatricula
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
