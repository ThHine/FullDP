using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Owin;
using Owin;
using WebBanHangOnline.Areas.Admin.Controllers;


[assembly: OwinStartupAttribute(typeof(WebBanHangOnline.Startup))]
namespace WebBanHangOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
