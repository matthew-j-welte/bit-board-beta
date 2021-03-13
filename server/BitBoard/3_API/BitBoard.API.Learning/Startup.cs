using System.IO;
using BitBoard.Business.Learning.Interfaces;
using BitBoard.Business.Learning.Mappings;
using BitBoard.Business.Learning.Services;
using BitBoard.Domain.Account.Models;
using BitBoard.Domain.Admin.Models;
using BitBoard.Domain.Learning.Models;
using BitBoard.Domain.Shared.Interfaces;
using BitBoard.Domain.Shared.Models;
using BitBoard.Domain.Shared.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BitBoard.API.Learning
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<CodeEditorConfiguration>, BaseRepository<CodeEditorConfiguration>>();
            services.AddScoped<IBaseRepository<Comment>, BaseRepository<Comment>>();
            services.AddScoped<IBaseRepository<ErrorReport>, BaseRepository<ErrorReport>>();
            services.AddScoped<IBaseRepository<LearningResource>, BaseRepository<LearningResource>>();
            services.AddScoped<IBaseRepository<LearningResourceSuggestion>, BaseRepository<LearningResourceSuggestion>>();
            services.AddScoped<IBaseRepository<Post>, BaseRepository<Post>>();
            services.AddScoped<IBaseRepository<Skill>, BaseRepository<Skill>>();
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();

            services.AddScoped<ILearningService, LearningService>();
            // services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddControllers();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

            // app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
