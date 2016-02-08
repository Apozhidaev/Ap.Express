using System.Web.Http;

namespace Express
{
    public static class HttpConfigurationExtensions
    {
        public static void UseStatic(this HttpConfiguration configuration, ContentOptions options)
        {
            __ContentController.Use(options);

            configuration.Routes.MapHttpRoute(
               name: "__Content",
               routeTemplate: "{*url}",
               defaults: new { controller = "__Content", action = "Get" }
           );
        }
    }
}
