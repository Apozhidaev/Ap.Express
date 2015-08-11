using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Ap.Express
{
    public class __StaticContentController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(Uri url)
        {
            var path = Path.Combine(AppConfig.Root, url != null ? url.OriginalString : AppConfig.DefaultUrl);
            if (File.Exists(path))
            {
                var mediaType = AppConfig.GetMediaType(Path.GetExtension(path));
                if (!String.IsNullOrEmpty(mediaType))
                {
                    var data = File.ReadAllBytes(path);
                    var eTag = String.Format("\"{0}\"", data.GetSHA1());
                    var ifNoneMatch = Request.Headers.IfNoneMatch.FirstOrDefault();
                    if (ifNoneMatch != null && ifNoneMatch.Tag == eTag)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    }
                    var response = new HttpResponseMessage { Content = new ByteArrayContent(data) };
                    response.Headers.ETag = new EntityTagHeaderValue(eTag);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
                    return response;
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
