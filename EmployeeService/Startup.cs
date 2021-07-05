using Helper;
using Helper.Handlers;
using Helper.Models;
using Helper.Repositories;
using MassTransit;
using MediatR;
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
using System.Reflection;
using System.Threading.Tasks;

namespace EmployeeService
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
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host("rabbitmq://localhost");
                }));
            });

            
            //services.AddMediatR(typeof(Request<Employee>));
            //services.AddMediatR(typeof(Helper.RequestHandler<Employee>));
            services.AddMassTransitHostedService();
            services.AddControllers();
            services.AddTransient<DBManager>();
            services.AddSingleton<IRepository<Employee>, EmployeeRepository>();
            services.AddSwaggerGen();
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(EmployeeRequestHandler));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            //var assembly = AppDomain.CurrentDomain.Load("Helper");
            //services.AddMediatR(assembly);
            //services.AddMediatR(typeof(Helper.mediatr.Request<>).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(Helper.RequestHandler<>).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(Request<Employee>));
            //services.AddMediatR(typeof(Helper.RequestHandler<Employee>));
            //services.RegisterRequestHandlers();
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
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Service");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public static class Dependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
            return services
                .AddMediatR(typeof(Dependencies).Assembly);
        }
    }
}
