using AutoMapper;
using GloboChat.Dominio.Entidades;
using GloboChat.Dominio.Interfaces.Repositorios;
using GloboChat.Infra.Data.Contexto;
using GloboChat.Infra.Data.Repositorios;
using GloboChat.Servicos.WebService.Hubs;
using GloboChat.Servicos.WebService.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace GloboChat.Servicos.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IHostingEnvironment _env { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSignalR();
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:5002");
            }));


            //Injetando Repositorios
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<ICanalRepository, CanalRepository>();


            var connection = "Data Source=GloboChat.db";
            //if (_env.WebRootPath == null)
            //    connection = "Data Source=GloboChat.db";
            //else
            //    connection = @"Data Source=D:\home\site\wwwroot\GloboChat.db";

            services.AddDbContext<GloboChatContext>(options =>
                options.UseSqlite(connection)
            );

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario,UsuarioViewModel > ();
                cfg.CreateMap<Usuario, UsuarioCadastroVModel>();

                cfg.CreateMap<UsuarioViewModel, Usuario> ();
                cfg.CreateMap<UsuarioViewModel, Pessoa>();
                cfg.CreateMap<UsuarioViewModel, Login>();

                cfg.CreateMap<UsuarioCadastroVModel, Usuario>();
                cfg.CreateMap<UsuarioCadastroVModel, Pessoa>();
                cfg.CreateMap<UsuarioCadastroVModel, Login>();

                cfg.CreateMap<string, DateTime>().ConvertUsing<StringToDateTimeConverter>();
            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
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

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/hubs/chat");
            });

            

        }

        
    }

    public class StringToDateTimeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source))
            {
                return default(DateTime);
            }

            if (DateTime.TryParse(source, out destination))
            {
                return destination;
            }

            return default(DateTime);
        }
    }
}
