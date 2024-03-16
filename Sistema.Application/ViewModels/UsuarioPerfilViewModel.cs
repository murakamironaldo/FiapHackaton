using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Domain.Entities;

namespace Sistema.Application.ViewModels
{
    public class UsuarioPerfilViewModel
    {  public Guid Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator UsuarioPerfilViewModel(UsuarioPerfil obj)
        {
            var model = new UsuarioPerfilViewModel
            {
                Id = obj.Id,
                Nome = obj.Nome
            };
            return model;
        }
    }
}
