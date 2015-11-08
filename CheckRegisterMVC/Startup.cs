using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckRegisterMVC.Startup))]
namespace CheckRegisterMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
