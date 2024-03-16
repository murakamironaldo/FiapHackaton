using Sistema.Domain.Entities;

namespace Sistema.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> Listar();
        Task<Usuario?> VerificaSenha(string login, string senha);
        Task<Usuario> Carregar(Guid id);
        void Excluir(Guid id);
    }
}
