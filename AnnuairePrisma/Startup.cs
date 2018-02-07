using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnnuairePrisma.Startup))]
namespace AnnuairePrisma
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
