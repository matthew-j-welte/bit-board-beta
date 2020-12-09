using System;
using System.Threading.Tasks;
using API.Data;
using API.Data.Seeding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<DataContext>();
                
                await context.Database.MigrateAsync();

                if (!(await context.Users.AnyAsync()))
                {
                    var dataQuery = new DataQuery();
                    await dataQuery.GenerateDataAsync();
                }  

                await Seed.SeedSkills(context);
                await Seed.SeedUsers(context);
                await Seed.SeedLearningResources(context);
                await Seed.SeedUserProgressions(context);
                await Seed.SeedPosts(context);
                await Seed.SeedComments(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred during migration");
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
