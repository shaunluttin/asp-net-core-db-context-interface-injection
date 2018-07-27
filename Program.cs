using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace temp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args);
            var host = builder.Build();

            using(var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<IdbContext>();
                var repo = services.GetRequiredService<IRepository>();

                Console.WriteLine("=======================");
                Console.WriteLine($"Program.cs > {context}");
                Console.WriteLine($"Program.cs > {repo}");
                Console.WriteLine("=======================");
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
