using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using PatientDA;
using Microsoft.EntityFrameworkCore;
using PatientBL.Services;

namespace PatientAPI
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
            //string connection = @"Server=DESKTOP-PU90CNF;Database=eHealthDB;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<IPatientData, PatientDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EHospitalDatabase")));
            services.AddScoped<IPatientService, PatientInfoService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "eHospital",
                    Description = "Patient web api for eHostpital Project",
                    TermsOfService = "Welcome everybody!",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact() { Name = "Alex Brylov", Email = "aksu@ukr.net" }
                });

            });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eHospital");
            });
        }
    }
}
