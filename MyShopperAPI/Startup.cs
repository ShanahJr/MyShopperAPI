using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyShopperAPI.Models;
using System;

namespace MyShopperAPI
{
    public class Startup
    {

        readonly string MyOrigin = "MyOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
           {
               options.AddPolicy(name: MyOrigin, builder =>
              {
                  //builder.WithOrigins("http://localhost:8100");
                  builder.AllowAnyMethod();
                  builder.AllowAnyHeader();
                  builder.AllowAnyOrigin();
              });

           });

            services.AddControllers()
                .AddNewtonsoftJson( options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore );
            services.AddDbContext<MyShopperContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("Database"), builder =>
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                ));
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

            app.UseCors(MyOrigin);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
