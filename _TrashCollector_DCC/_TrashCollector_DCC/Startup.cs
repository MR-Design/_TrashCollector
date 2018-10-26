using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_TrashCollector_DCC.Startup))]
namespace _TrashCollector_DCC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
