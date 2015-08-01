using System;
using Microsoft.Owin.Hosting;

namespace Ap.Express.Static
{
    public class App
    {
        private IDisposable _webApp;

        public void Start()
        {

            _webApp = WebApp.Start<Startup>("http://localhost:3838/");
        }

        public void Stop()
        {
            if (_webApp != null)
            {
                _webApp.Dispose();
                _webApp = null;
            }
        }
    }
}