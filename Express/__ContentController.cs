using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Express
{
    public class __ContentController : ApiController
    {
        private static ContentOptions _options;

        public static void Use(ContentOptions options)
        {
            _options = options;
        }

        [HttpGet]
        public HttpResponseMessage Get(Uri url)
        {
            var path = Path.Combine(_options.Root, url?.OriginalString ?? _options.DefaultUrl);
            if (TryFindContent(ref path))
            {
                var mediaType = _options.GetMediaType(Path.GetExtension(path));
                if (!String.IsNullOrEmpty(mediaType))
                {
                    var data = File.ReadAllBytes(path);
                    var eTag = data.GetETag();
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

        private bool TryFindContent(ref string path)
        {
            if (!String.IsNullOrEmpty(_options.DefaultCulture) 
                && (_options.CultureResources.Count == 0 || _options.CultureResources.Contains(Path.GetFileName(path))))
            {
                foreach (var headerValue in Request.Headers.AcceptLanguage)
                {
                    var culture = headerValue.Value;
                    if (_options.DefaultCulture == culture) break;
                    var culturePath = Path.ChangeExtension(path, String.Concat(culture, Path.GetExtension(path)));
                    if (File.Exists(culturePath))
                    {
                        path = culturePath;
                        return true;
                    }
                }
            }
            return File.Exists(path);
        }
    }
}
