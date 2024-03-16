using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sistema.Domain.Entities;
using Sistema.Infra.Database.Mappings;



namespace Sistema.Infra.Database
{
    public class SistemaDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public SistemaDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioPerfil> UsuarioPerfis { get; set; }
        public virtual DbSet<UsuarioPerfilAcesso> UsuarioPerfilAcessos { get; set; }
        public virtual DbSet<UsuarioTelefone> UsuarioTelefones { get; set; }

        public virtual DbSet<Configuracao> Configuracoes{ get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EmpresaMap.Map(modelBuilder);
            UsuarioMap.Map(modelBuilder);
            UsuarioPerfilMap.Map(modelBuilder);
            UsuarioPerfilAcessoMap.Map(modelBuilder);
            UsuarioTelefoneMap.Map(modelBuilder);
            TelefoneTipoMap.Map(modelBuilder);
            ConfiguracaoMap.Map(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var versao = new MariaDbServerVersion("11.2.2-MariaDB");
            //var connectionstring = "Server=127.0.0.1;Port=3306;DataBase=Sistema;Uid=root;Pwd=luciana;Allow User Variables=True;Default Command Timeout=120;";




            var connectionstring = _configuration["ConnectionStrings:DefaultConnection"];
            var versao = _configuration["ConnectionStrings:VersionDatabase"];

            optionsBuilder.UseMySql(connectionstring, new MySqlServerVersion(new Version(8, 0, 25)));

        }

    }
}
