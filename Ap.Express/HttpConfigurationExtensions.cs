using System.Web.Http;

namespace Ap.Express
{
    public static class HttpConfigurationExtensions
    {
        public static void UseStatic(this HttpConfiguration configuration, string root)
        {
            AppSettings.UseStatic(root);

            configuration.Routes.MapHttpRoute(
               name: "__Content",
               routeTemplate: "{*url}",
               defaults: new { controller = "__Content", action = "Get" }
           );
        }
    }
}
