using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Biblioteca.Data.Models;
using Biblioteca.Repository;
using Biblioteca.Service;
using Biblioteca.Service.InterfacesServicio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BibliotecaApi
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
            //Se agrega los contextos de datos y el servicio de la seguridad
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BibliotecaContext")));
            services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            //Servicios 
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IAutorServicio), typeof(AutorServicio));
            services.AddTransient(typeof(ITemaServicio), typeof(TemaServicio));


            //JWT autenticacion.
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(cfg =>
                        {
                            cfg.RequireHttpsMetadata = false;
                            cfg.SaveToken = true;
                            cfg.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = Configuration["Jwt:Issuer"],
                                ValidAudience = Configuration["Jwt:Issuer"],
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                            };
                        });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFromAll",
                    builder => builder
                    .WithMethods("GET", "POST")
                    .AllowAnyOrigin()
                    .AllowAnyHeader());
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseCors("AllowFromAll");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "Role",
                    template: "{controller=Role}/{action=Index}/{Role?}");
            });
        }
    }
}
