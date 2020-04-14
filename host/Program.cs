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
            // Task.Run(async () =>
            // {
            //     await Task.Delay(3000);
            //     // todo: WTF???
            //     AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            //     var channel = Grpc.Net.Client.GrpcChannel.ForAddress("http://localhost:5005");
            //     var client = new company.companyClient(channel);
            //     var reply = client.Create(new CreateRequest()
            //     {
            //         Id = 1,
            //         Name = "body.Name"
            //     });
            //     var test = reply.Uid;
            // });
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
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
