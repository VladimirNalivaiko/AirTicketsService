using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirTicketsService.Startup))]
namespace AirTicketsService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
