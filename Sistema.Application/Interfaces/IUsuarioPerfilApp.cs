using Sistema.Application.ViewModels;

namespace Sistema.Application.Interfaces
{
    public interface IUsuarioPerfilApp
    {
        Task<IEnumerable<UsuarioPerfilViewModel>> Listar();
    }
}
