using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Ap.Express
{
    public class __StaticContentController : ApiController
    {
        private static readonly string RootPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, AppConfig.Root));

        [HttpGet]
        public HttpResponseMessage Get(string url)
        {
            var path = Path.GetFullPath(Path.Combine(AppConfig.Root, url));
            if (RootPath == path.Substring(0, RootPath.Length) && File.Exists(path))
            {
                var mediaType = AppConfig.GetMediaType(Path.GetExtension(path));
                if (!String.IsNullOrEmpty(mediaType))
                {
                    var response = new HttpResponseMessage { Content = new ByteArrayContent(File.ReadAllBytes(path)) };
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
                    return response;
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
