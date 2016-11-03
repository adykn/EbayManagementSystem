using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMSc.Startup))]
namespace EMSc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
