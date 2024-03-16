using Microsoft.EntityFrameworkCore;
using Sistema.Domain.Entities;

namespace Sistema.Infra.Database.Mappings
{
    public class ConfiguracaoMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuracao>(entity =>
            {
                entity.ToTable("Configuracoes");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Variavel).IsRequired().HasMaxLength(80);
                entity.Property(x => x.Valor).HasMaxLength(5000).IsRequired();
            });
        }
    }
}
