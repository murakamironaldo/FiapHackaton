using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Domain.Entities;

namespace Sistema.Infra.Database.Mappings
{
    public class UsuarioMap 
    {
        public static void Map(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Nome)
                    .HasMaxLength(80)
                    .IsRequired();
                entity.Property(x => x.Login)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(x => x.Documento)
                    .HasMaxLength(50);
                entity.Property(x => x.Email)
                    .HasMaxLength(100)
                    .IsRequired();
                entity.Property(x => x.MacAddress)
                    .HasMaxLength(5000);
                entity.Property(x => x.ListaIps)
                    .HasMaxLength(5000);
                entity.Property(x => x.Senha)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(x => x.VerificaIP);
                entity.Property(x => x.VerificaMacAddress);
                entity.Property(x => x.DataUltimoAcesso);
                entity.Property(x => x.DataUltimaTrocaSenha);
                entity.Property(x => x.QuantidadeTentativasLogin);
                entity.Property(x => x.TrocarSenha);
                entity.Property(x => x.UsuarioPerfilId);
                entity.Property(x => x.EmpresaId);
                entity.HasOne(x => x.Empresa)
                    .WithMany()
                    .HasForeignKey(x => x.EmpresaId);
                entity.HasOne(x => x.UsuarioPerfil)
                    .WithMany()
                    .HasForeignKey(x => x.UsuarioPerfilId);
                entity.Property(x => x.UsuarioTrocaSenhaId);
                entity.Property(x => x.TrocarSenha);
            });


          
            
        }
    }
}