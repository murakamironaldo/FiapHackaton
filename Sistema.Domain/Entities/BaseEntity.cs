using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
            ModificadoEm = DateTime.Now;
            FlgStatus = "A";
        }
        [Column(TypeName="uuid")] 
        public Guid Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime ModificadoEm { get; private set; }
        public  string FlgStatus { get; set; }
    }
}
