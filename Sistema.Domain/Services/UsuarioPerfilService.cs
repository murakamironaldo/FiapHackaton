using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Domain.Entities;
using Sistema.Domain.Interfaces.Repositories;
using Sistema.Domain.Interfaces.Services;

namespace Sistema.Domain.Services
{
    public class UsuarioPerfilService:IUsuarioPerfilService
    {
        private readonly IUsuarioPerfilRepository _perfilrepository;

        public UsuarioPerfilService(IUsuarioPerfilRepository perfilRepository)
        {
            _perfilrepository = perfilRepository;
        }

        public async Task<IEnumerable<UsuarioPerfil>> Listar()
        {
            var lista = _perfilrepository.ListarTodos().OrderBy(m=>m.Nome);
            return lista;
        }
    }
}
