using ControleVeicular.Application;
using ControleVeicular.Application.Interfaces;
using ControleVeicular.Domain.Interfaces.Repositories;
using ControleVeicular.Domain.Interfaces.Services;
using ControleVeicular.Domain.Services;
using ControleVeicular.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ControleVeicular.API
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
            services.AddTransient(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddTransient<IMarcaAppService, MarcaAppService>();
            services.AddTransient<IModeloAppService, ModeloAppService>();
            services.AddTransient<IAnuncioAppService, AnuncioAppService>();
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();

            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient<IMarcaService, MarcaService>();
            services.AddTransient<IModeloService, ModeloService>();
            services.AddTransient<IAnuncioService, AnuncioService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IMarcaRepository, MarcaRepository>();
            services.AddTransient<IModeloRepository, ModeloRepository>();
            services.AddTransient<IAnuncioRepository, AnuncioRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddControllers();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

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
