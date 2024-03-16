using Sistema.Application.Interfaces;
using Sistema.Application.ViewModels;
using Sistema.Domain.Interfaces.Services;

namespace Sistema.Application.Applications
{
    public class UsuarioPerfilApp:IUsuarioPerfilApp
    {
        private readonly IUsuarioPerfilService _usuarioPerfilService;
        public UsuarioPerfilApp(IUsuarioPerfilService usuarioPerfilService)
        {
            _usuarioPerfilService = usuarioPerfilService;
        }
        public async Task<IEnumerable<UsuarioPerfilViewModel>> Listar()
        {
            var lista = await _usuarioPerfilService.Listar();
            var retorno = new List<UsuarioPerfilViewModel>();

            foreach (var item in lista)
            {
                var viewModel = (UsuarioPerfilViewModel) item;
                retorno.Add(viewModel);
            }
            return retorno;
        }
    }
}
