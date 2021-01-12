using AutoMapper;
using ControleVeicular.Application;
using ControleVeicular.Application.Interfaces;
using ControleVeicular.Domain.Interfaces.Repositories;
using ControleVeicular.Domain.Interfaces.Services;
using ControleVeicular.Domain.Services;
using ControleVeicular.Infra.Data.Repositories;
using ControleVeicular.Web.AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ControleVeicular.Web
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

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.  
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie("Cookies", options => { options.LoginPath = "/usuarios/login"; });
            services.AddMvc();
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

            app.UseAuthentication();
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
