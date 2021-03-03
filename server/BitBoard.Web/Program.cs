using System.Threading.Tasks;
using API.Data.Seeding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace API
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
