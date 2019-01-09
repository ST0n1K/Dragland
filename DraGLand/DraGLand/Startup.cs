using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DraGLand.Startup))]
namespace DraGLand
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
