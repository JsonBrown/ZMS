using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZMS.Data.Applicants;
using ZMS.Data.Equipment;

namespace ZMS
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
            // enable below for in memory testing

            // Applicant
            services.AddSingleton<IApplicantData, InMemoryApplicantData>();

            // Equipment
            services.AddSingleton<IGearData, InMemoryGearData>();


            //enable below for sql server

            //Equipment
            /*services.AddScoped<IGearData, SqlGearData>();
            services.AddDbContextPool<EquipmentDbContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("ZMSDb")); });*/

            // Applicant
            /*services.AddScoped<IApplicantData, SqlApplicantData>();
            services.AddDbContextPool<ApplicantDbContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("ZMSDb")); });*/

            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
