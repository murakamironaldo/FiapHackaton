using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Domain.Entities;

namespace Sistema.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Guid PerfilId { get; set; }
        public string Documento { get; set; }

        public List<UsuarioTelefoneViewModel> Telefones { get; set; } 
        public string TelefonesStr { get; set; }

        public static explicit operator UsuarioViewModel(Usuario obj)
        {
            var model = new UsuarioViewModel
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Email = obj.Email,
                Login = obj.Login,
                Senha = obj.Senha, 
                PerfilId = obj.UsuarioPerfilId, 
                Documento = obj.Documento
                
                
            };
            var telefoneNumero = new List<string>();
            model.Telefones = new List<UsuarioTelefoneViewModel>();
            foreach (var item in obj.UsuarioTelefones)
            {
                model.Telefones.Add((UsuarioTelefoneViewModel)item);
                telefoneNumero.Add(item.Numero);
            }
            model.TelefonesStr = string.Join(",", telefoneNumero);

            return model;
        }
    }
}
