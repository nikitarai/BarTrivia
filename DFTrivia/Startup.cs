using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DFTrivia.Startup))]
namespace DFTrivia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
