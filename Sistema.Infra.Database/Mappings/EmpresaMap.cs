using Microsoft.EntityFrameworkCore;
using Sistema.Domain.Entities;

namespace Sistema.Infra.Database.Mappings
{
    public class EmpresaMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresas");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.NomeFantasia).IsRequired().HasMaxLength(80);
                entity.Property(x => x.RazaoSocial).HasMaxLength(80).IsRequired();
            });
        }
    }
}
