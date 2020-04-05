using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocio.Dominio.Entidades;

namespace Infraestrutura.Dados.Mapeamento 
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> modelBuilder)
        {
            modelBuilder.ToTable("PRODUTO");
            // Propriedades.
            modelBuilder
                .HasKey(x => x.CodigoProduto);
            
            modelBuilder
                .Property(x => x.CodigoProduto)
                .HasColumnType("char(4)")
                .HasColumnName("COD_PRODUTO");

            modelBuilder
                .Property(x => x.DescricaoProduto)
                .HasMaxLength(30)
                .HasColumnName("DES_PRODUTO");
            
            modelBuilder
                .Property(x => x.Status)
                .HasColumnType("char(1)")
                .HasColumnName("STA_STATUS");
        }
    }
}