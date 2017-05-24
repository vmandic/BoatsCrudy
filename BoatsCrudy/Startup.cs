using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoatsCrudy.Startup))]
namespace BoatsCrudy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
