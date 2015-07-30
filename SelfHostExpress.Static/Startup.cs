using System.Web.Http;
using Owin;

namespace SelfHostExpress.Static
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();


            config.UseStatic("..\\..\\Web\\");


            appBuilder.UseWebApi(config);
        }

    }
}
