using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieRentalManagementSystem.Startup))]
namespace MovieRentalManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
