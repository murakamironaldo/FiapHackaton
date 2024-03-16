using Sistema.Domain.Entities;

namespace Sistema.Domain.Interfaces.Services
{
    public interface IUsuarioPerfilService
    {
        Task<IEnumerable<UsuarioPerfil>> Listar();
    }
}
