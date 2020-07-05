using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Posts.Likes.Api.Filters;
using Posts.Likes.Application.Configurations;
using Posts.Likes.Application.Validators;
using Posts.Likes.Infrastructure;
using Posts.Likes.Infrastructure.Configurations;
using Posts.Likes.Infrastructure.Services;

namespace Posts.Likes.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MongoConfiguration>(Configuration.GetSection(nameof(MongoConfiguration)));

            services.AddSingleton<IMongoConfiguration>(o => o.GetRequiredService<IOptions<MongoConfiguration>>().Value);

            services.AddSingleton<LikeDbContext>();

            services.AddSingleton<ILikeService, LikeService>();

            services.AddApplication();

            services
                .AddControllers(o => o.Filters.Add(typeof(GlobalExceptionFilter)))
                .AddNewtonsoftJson(o => o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore)
                .AddFluentValidation(o => o.RegisterValidatorsFromAssemblyContaining<LikeValidator>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}