namespace Sistema.Domain.Entities
{
    public class Configuracao:BaseEntity
    {
        public string Variavel { get; private set; }
        public string Descricao { get; private set; }
        public string Valor { get; private set; }


        public void AlterarValor(string valor)
        {
            Valor = valor;
        }
    }
}
