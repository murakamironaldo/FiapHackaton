using Sistema.Domain.Entities;
using Sistema.Domain.Interfaces.Repositories;

namespace Sistema.Infra.Database.Repositories
{
    public class UsuarioRepository:Repository<Usuario>,IUsuarioRepository
    {
        public UsuarioRepository(SistemaDbContext context) : base(context)
        {
        }
    }
}
