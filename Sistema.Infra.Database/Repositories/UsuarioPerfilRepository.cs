using Sistema.Domain.Entities;
using Sistema.Domain.Interfaces.Repositories;

namespace Sistema.Infra.Database.Repositories
{
    public class UsuarioPerfilRepository:Repository<UsuarioPerfil>,IUsuarioPerfilRepository
    {
        public UsuarioPerfilRepository(SistemaDbContext context) : base(context)
        {
        }
    }
}
