using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4SwaggerAPI.Services.Abstract;
using _4SwaggerAPI.Services.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace _4SwaggerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ICarService, CarManager>();
            services.AddScoped<ICarDal, EfCarDal>();
            services.AddScoped<IRentalService, RentalManager>();
            services.AddScoped<IRentalDal, EfRentalDal>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddSwaggerGen(opt => {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    { Title = "SwaggerAPI", Version = "v1" });
            });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            SwaggerOpt.SwaggerOpt _opt = new SwaggerOpt.SwaggerOpt();
            Configuration.GetSection("SwaggerOpt").Bind(_opt);

            app.UseSwagger(op => { op.RouteTemplate = _opt.Route; });

            app.UseSwaggerUI(op => { op.SwaggerEndpoint(_opt.EndPoint, _opt.Title); });
        }
    }
}
