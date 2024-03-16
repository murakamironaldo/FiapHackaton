using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sistema.Domain.Entities;

namespace Sistema.Infra.Database.Mappings
{
    public class UsuarioPerfilAcessoMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioPerfilAcesso>(entity =>
            {
                entity.ToTable("UsuarioPerfilAcessos");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Nome).HasMaxLength(80).IsRequired();
            });
        }
    }
}
