using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Petnb_MVC5.Startup))]
namespace Petnb_MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
