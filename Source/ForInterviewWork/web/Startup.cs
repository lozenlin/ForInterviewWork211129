using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Data.Domain.Models;
using Common.DataAccess.EFCore;
using Common.Services;
using Common.Services.DataAccess;
using Common.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <history>
        /// 2021/11/27, lozenlin, modify, 串接 service layer, data access layer, 資料庫連接字串
        /// </history>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FIWContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                    .UseLoggerFactory(LoggerFactory.Create(builder =>
                    {
                        builder.AddConsole().AddDebug();
                    }))
                    .EnableSensitiveDataLogging();
            });

            services.AddScoped<IEmployeeDataAccess, EmployeeDataAccess>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
