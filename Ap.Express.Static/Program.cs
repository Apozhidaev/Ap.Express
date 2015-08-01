using System;

namespace Ap.Express.Static
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new App();
            app.Start();
            Console.ReadKey();
            app.Stop();
        }
    }
}
