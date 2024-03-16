using Sistema.Domain.Entities;
using Sistema.Domain.Interfaces.Repositories;

namespace Sistema.Infra.Database.Repositories
{
    public class ConfiguracaoRepository:Repository<Configuracao>,IConfiguracaoRepository
    {
        public ConfiguracaoRepository(SistemaDbContext context) : base(context)
        {
        }
    }
}
