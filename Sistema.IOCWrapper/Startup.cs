using Microsoft.Extensions.DependencyInjection;
using Sistema.Application.Applications;
using Sistema.Application.Interfaces;
using Sistema.Domain.Interfaces.Repositories;
using Sistema.Domain.Interfaces.Services;
using Sistema.Domain.Services;
using Sistema.Infra.Database;
using Sistema.Infra.Database.Repositories;

namespace Sistema.IOCWrapper
{
    public static class Startup
    {
        public static void Bootstrap(IServiceCollection services)
        {
            services.AddDbContext<SistemaDbContext>();
            #region Usuarios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioApp, UsuarioApp>();
            services.AddScoped<IUsuarioPerfilApp, UsuarioPerfilApp>();
            services.AddScoped<IUsuarioPerfilService, UsuarioPerfilService>();
            services.AddScoped<IUsuarioPerfilRepository, UsuarioPerfilRepository>();
            #endregion
            #region Configuracoes
            services.AddScoped<IConfiguracaoRepository, ConfiguracaoRepository>();
            services.AddScoped<IConfiguracaoService, ConfiguracaoService>();
            services.AddScoped<IConfiguracaoApp, ConfiguracaoApp>();


            #endregion
        }
    }
}
