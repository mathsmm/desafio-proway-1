using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaAlf_API.Data;
using EscolaAlf_API.Data.Interfaces;
using EscolaAlf_API.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EscolaAlf_API
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

            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("Connection")
                )
            );

            services.AddControllers()
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling = 
                            ReferenceLoopHandling.Ignore
                    );

            services.AddScoped<AverageCalculationService>();
            services.AddScoped<GradeCalculationService>();
            services.AddScoped<IRepository, RepositoryService>();
            services.AddScoped<IStudent, StudentService>();
            services.AddScoped<IStudentGrade, StudentGradeService>();
            services.AddScoped<IStudentReply, StudentReplyService>();
            services.AddScoped<IStudentSituation, StudentSituationService>();
            services.AddScoped<ITemplate, TemplateService>();
            services.AddScoped<ITestQuestion, TestQuestionService>();
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

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
