using Consultancy.Data.Database;
using Consultancy.Service.Consultant;
using AutoMapper;
using Consultancy.Service.Mission;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Consultancy.API.Mapper;

namespace Consultancy.API
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
            services
            .AddControllers()
            .AddNewtonsoftJson(
               options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddDbContext<ConsultingContext>(options =>
            {
                options.UseSqlServer(@"Data Source=DESKTOP-5ARGQ5B\MSSQLSERVER01;Initial Catalog=localdb;Integrated Security=True");
            });
            services.AddScoped<IMissionService, MissionService>();
            services.AddScoped<IConsultantService, ConsultantService>();
            services.AddAutoMapper(typeof(ConsultantMapperProfile));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
