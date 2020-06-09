using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationsApp.FluentValidations;
using FluentValidationsApp.Models;
using FluentValidationsApp.Models.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;

namespace FluentValidationsApp
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
            //servis containerına automapper servisi eklenir böylece sınıflarda kolayca inject edilebiliecek
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("FluentDbCon"));
                //options.UseSqlServer(Configuration["FluentDbCon"]);

            });

            //projede kullanılan validator sınıflarını service containerı içine tek tek eklemek için 
            //services.AddSingleton<IValidator<Customer>, CustomerValidatior>();

            //proeje fluent validations eklenir
            services.AddControllersWithViews()
                .AddFluentValidation(options =>
                {//projede kullanılan validator sınıflarını tek tek eklemek yerine bu metod kullanılarak startup sınıfına ait assembly içindeki IValidator interfaceini implemente eden tüm sınıfları burada containera ekleyebilirz
                    options.RegisterValidatorsFromAssemblyContaining<Startup>();
                });

            //default modelstate filterı kapatıldı custom olarak handle edilecek
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
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
