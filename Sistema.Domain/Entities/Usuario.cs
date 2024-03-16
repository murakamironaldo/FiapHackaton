namespace Sistema.Domain.Entities
{
    public class Usuario:BaseEntity
    {
        

        public Guid EmpresaId { get; private set; }
        public Empresa Empresa { get; private set; }
        public string Nome { get; private set; }
        public UsuarioPerfil UsuarioPerfil { get; private set; }
        public Guid UsuarioPerfilId { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }
        public bool VerificaIP { get; private set; }    
        public string ListaIps { get;private set; }
        public bool VerificaMacAddress { get; private set; }
        public string MacAddress { get; private set; }
        public DateTime DataUltimoAcesso { get; private set; }
        public DateTime DataUltimaTrocaSenha { get; private set; }
        public int QuantidadeTentativasLogin { get; private set; }
        public bool TrocarSenha { get;private set; }
        public Guid? UsuarioTrocaSenhaId { get; private set; }
        public IList<UsuarioTelefone> UsuarioTelefones { get; private set; }

    }
}
