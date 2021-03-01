using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OSProjects.Services.ProjectService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSProjects.Data;
using IBM.EntityFrameworkCore;
using IBM.EntityFrameworkCore.Storage.Internal;

namespace OSProjects
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
            services.AddDbContext<DataContext>(i_Options => i_Options.UseDb2(Configuration.GetConnectionString("DefaultConnection"),
                                               i_Context => i_Context.SetServerInfo(IBMDBServerType.AS400, IBMDBServerVersion.AS400_07_02)));

            services.AddControllers();

            services.AddRazorPages();

            // Mapper

            // Scope
            services.AddScoped<IProjectServices, ProjectServices>();
            
            // CORS
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
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
            app.UseCors("MyPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
