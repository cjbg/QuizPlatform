using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizPlatform.Startup))]
namespace QuizPlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
