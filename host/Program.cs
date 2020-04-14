using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // webBuilder.ConfigureKestrel(options =>
                    // {
                    //     options.Listen(System.Net.IPAddress.Any, 5005, listenOptions =>
                    //     {
                    //         listenOptions.Protocols = HttpProtocols.Http2;
                    //     });
                    // });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
