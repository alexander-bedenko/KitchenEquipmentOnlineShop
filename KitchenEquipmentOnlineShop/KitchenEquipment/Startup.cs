﻿using AutoMapper;
using KitchenEquipment.Infrastructure;
using KitchenEquipmentOnlineShop.BusinessLogic.Infrastructure;
using KitchenEquipmentOnlineShop.BusinessLogic.Interfaces;
using KitchenEquipmentOnlineShop.BusinessLogic.Services;
using KitchenEquipmentOnlineShop.DataAccess.EF;
using KitchenEquipmentOnlineShop.DataAccess.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KitchenEquipment
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Auto Mapper Configurations
            Mapper.Initialize(x =>
            {
                AutoMapperWebConfig.ConfigAction.Invoke(x);
                AutoMapperBllConfig.ConfigAction.Invoke(x);
            });

            services.AddMvc();
            services.AddMvc().AddControllersAsServices();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.LoginPath = new PathString("/account/login"));

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.RegisterBllServices(Configuration);
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IKitchenEquipmentContext, KitchenEquipmentContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IExhaustHoodService, ExhaustHoodService>();
            services.AddTransient<ISinkService, SinkService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();

            //Perform middleware for custom 404 page
            app.Use(async (context, next) => {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/Error";
                    await next();
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
