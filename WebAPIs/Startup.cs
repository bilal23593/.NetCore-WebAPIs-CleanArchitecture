using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Data.IRepositories;
using Data.Repositories;
using Database;
using Domain.Common.Mapping;
using Domain.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPIs
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
            services
                .AddCors()
                .AddControllers()
                ;

            services
                .AddMvc()
                ;

            services.AddDbContext<UHSToolDBContext>(options =>

                options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddScoped<ILoginRepository, LoginRepository>();
            services
                .AddLogic(Configuration)
                .AddMediatR(typeof(LogicServiceCollectionExtensions).Assembly)


                ;

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSwaggerGen(
                gen =>
                {
                    gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "UHSTool Web API", Version = "v1.0" });
                }
                );
            // /swagger/v1.0/swagger.json
            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
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

            app.UseSwagger();
            app.UseSwaggerUI(ui => {
                ui.SwaggerEndpoint("/swagger/v1.0/swagger.json", "UHSTool Server API Endpoint");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
