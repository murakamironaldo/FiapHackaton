using Sistema.Domain.Entities;

namespace Sistema.Domain.Interfaces.Services
{
    public interface IConfiguracaoService
    {
        IEnumerable<Configuracao> Listar();
        Configuracao? Carregar(Guid id);
        IEnumerable<Configuracao> Listar(string grupoVariaveis);
        void Alterar(Guid id, string valor);
    }
}
