namespace Sistema.Domain.Entities
{
    public class UsuarioTelefone:BaseEntity
    {
        public string Numero { get; private set; }
        public Usuario Usuario { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Guid TelefoneTipoId { get; private set; }
        public TelefoneTipo TelefoneTipo { get; private set; }
    }
}
