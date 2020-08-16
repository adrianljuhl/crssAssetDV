using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(crssAssetDV.Startup))]
namespace crssAssetDV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
