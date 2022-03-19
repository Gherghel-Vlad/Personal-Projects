using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatBot.Startup))]
namespace ChatBot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
