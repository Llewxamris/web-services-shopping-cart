using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mHaley_C50_A03.Startup))]
namespace mHaley_C50_A03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
