using BL;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaManagement
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoronaManagement", Version = "v1" });
            });

            services.AddScoped<IPatientDAL, PatientDAL>();
            services.AddScoped<ICoronaVaccineDAL, CoronaVaccineDAL>();
            services.AddScoped<IListOpatientDAL, ListOpatientDAL>();
            services.AddScoped<IVaccineManufacturerDAL, VaccineManufacturerDAL>();
            services.AddScoped<IPatientBL,PatientBL>();
            services.AddScoped<ICoronaVaccineBL, CoronaVaccineBL>();
            services.AddScoped<IListOpatientBL, ListOpatientBL>();
            services.AddScoped<IVaccineManufacturerBL, VaccineManufacturerBL>();

            services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
                });
            

    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyAllowSpecificOrigins");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoronaManagement v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
