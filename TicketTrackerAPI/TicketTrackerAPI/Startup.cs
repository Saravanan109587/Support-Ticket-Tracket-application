using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TicketTrackerAPI.HUBS;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using TicketTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TicketTrackerAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddElmah(options =>
            {
                options.LogPath = "~/Elmahlog"; // OR options.LogPath = "с:\errors";
            });

            services.AddCors(option => option.AddPolicy("CorsPolicy", builder =>
             {
                 builder.AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowAnyOrigin()
                 .AllowCredentials();


             }));

            services.AddSignalR();
            var connection = Configuration["TicketTrackerContext"];
            services.AddDbContext<TicketTrackerContext>(options => options.UseSqlServer(connection));
            //var containerBuilder = new Autofac.ContainerBuilder();

            //containerBuilder.RegisterType<TestClass>().As<ITicketNotifier>().InstancePerLifetimeScope();
            //// containerBuilder.RegisterCallback<ITicketNotifierHub, TicketNotifierHub>();
            //containerBuilder.Populate(services);
            //var container = containerBuilder.Build();

            //return new AutofacServiceProvider(container);

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors("CorsPolicy");
             
            app.UseSignalR(route =>
            {
                route.MapHub<TicketNotifierHub>("/TicketNotificationHub");
            });
            app.UseElmah();
        }

        
        }
    }
 