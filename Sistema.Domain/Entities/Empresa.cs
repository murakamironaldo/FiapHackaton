namespace Sistema.Domain.Entities
{
    public class Empresa:BaseEntity
    {
        public Empresa(string razaoSocial, string nomeFantasia)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
        }

        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; set; }
    }
}
