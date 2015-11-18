using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BierenMVCSecurity.Startup))]
namespace BierenMVCSecurity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
