using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoUpload.Startup))]
namespace DemoUpload
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
