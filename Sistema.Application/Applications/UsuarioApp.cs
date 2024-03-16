using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Application.Interfaces;
using Sistema.Application.ViewModels;
using Sistema.Domain.Interfaces.Services;

namespace Sistema.Application.Applications
{
    public class UsuarioApp:IUsuarioApp
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioApp(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IEnumerable<UsuarioViewModel>> Listar()
        {
            var lista = await _usuarioService.Listar();
            var retorno = new List<UsuarioViewModel>();

            foreach (var item in lista)
            {
                var viewModel = (UsuarioViewModel)item;
                retorno.Add(viewModel);
            }
            return retorno;
        }

        public async Task<UsuarioViewModel>? VerificaSenha(string login, string senha)
        {
            var user = _usuarioService.VerificaSenha(login, senha);
            if (user.Result == null)
            {
                return null;
            }
            else
            {
                return (UsuarioViewModel)user.Result;
            }
        }

        public async Task<UsuarioViewModel> Carregar(Guid id)
        {
            var retorno = _usuarioService.Carregar(id);
            if (retorno == null)
            {
                return null;
            }
            else
            {
                return (UsuarioViewModel) retorno.Result;
            }

        }

        public Task Excluir(Guid id)
        {
            _usuarioService.Excluir(id);
            return Task.CompletedTask;
        }
    }
}
