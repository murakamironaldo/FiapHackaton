using Sistema.Domain.Entities;

namespace Sistema.Application.ViewModels
{
    public class UsuarioTelefoneViewModel
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }

        public static explicit operator UsuarioTelefoneViewModel(UsuarioTelefone obj)
        {
            var model = new UsuarioTelefoneViewModel
            {
                Id = obj.Id,
                Numero = obj.Numero
            };
            return model;
        }
    }
}
