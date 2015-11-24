using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rf222cz_1_2_aventyrliga_kontakter.Startup))]
namespace rf222cz_1_2_aventyrliga_kontakter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
