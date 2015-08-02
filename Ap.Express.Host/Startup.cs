using System.Web.Http;
using Ap.Express.Host.Configuration;
using Owin;

namespace Ap.Express.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.UseStatic(AppConfig.Root);
            appBuilder.UseWebApi(config);
        }

    }
}