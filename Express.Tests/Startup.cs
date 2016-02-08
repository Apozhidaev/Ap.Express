using System.Web.Http;
using Express.Tests.Configuration;
using Owin;

namespace Express.Tests
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.UseStatic(new ContentOptions(AppSettings.Root).UseWeb().UseCulture());
            appBuilder.UseWebApi(config);
        }

    }
}
