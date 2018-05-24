using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigDataNewsAPI.Startup))]
namespace BigDataNewsAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
