using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LifeInsuranceWeb.Startup))]
namespace LifeInsuranceWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
