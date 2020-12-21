using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestNotes.Models;

namespace RestNotes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureDevelopment(app, env);
            ConfigureSwagger(app);

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigureNotesContextService(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestNotes", Version = "v1" });
            });
        }

        private static void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment()) return;

            app.UseDeveloperExceptionPage();
        }

        private static void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestNotes v1"));
        }

        private static void ConfigureNotesContextService(IServiceCollection services)
        {
            services.TryAddSingleton(typeof(INotesContext), typeof(NotesListContext));
        }
    }
}
