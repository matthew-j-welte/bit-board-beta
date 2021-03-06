using System.Threading.Tasks;
using BitBoard.API.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BitBoard.API.Learning
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length > 0 && args[0].Equals("--seed"))
            {
                var seed = new Seed();
                await seed.ClearData();
                await seed.GenerateRandomDataAsync();
            }
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
