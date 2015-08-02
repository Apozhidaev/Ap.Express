﻿using System;
using Topshelf;
using Ap.Express.Host.Configuration;

namespace Ap.Express.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<App>(s =>
                {
                    s.ConstructUsing(name => new App());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription(AppConfig.Description);
                x.SetDisplayName(AppConfig.DisplayName);
                x.SetServiceName(AppConfig.ServiceName);
            });
        }
    }
}
