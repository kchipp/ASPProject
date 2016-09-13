using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPProject.Startup))]
namespace ASPProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
