using System.Web.Http;

namespace SelfHostExpress
{
    public static class HttpConfigurationExtensions
    {
        public static void UseStatic(this HttpConfiguration configuration, string root)
        {
            AppConfig.Root = root;

            configuration.Routes.MapHttpRoute(
               name: "__StaticContent",
               routeTemplate: "{*url}",
               defaults: new { controller = "__StaticContent", action = "Get" }
           );
        }
    }
}
