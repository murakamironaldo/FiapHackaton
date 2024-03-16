using Sistema.Application.ViewModels;

namespace Sistema.Application.Interfaces
{
    public interface IConfiguracaoApp
    {
        Task<IEnumerable<ConfiguracaoViewModel>> Listar();
        Task<ConfiguracaoViewModel> Carregar(Guid id);
        Task<IEnumerable<ConfiguracaoViewModel>> Listar(string grupo);
        Task Alterar(Guid id, string valor);
    }
}
