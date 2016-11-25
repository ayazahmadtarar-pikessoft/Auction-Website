using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(auction.Startup))]
namespace auction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
