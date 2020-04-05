using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocio.Dominio.Entidades;

namespace Infraestrutura.Dados.Mapeamento
{
    public class ProdutoCosifMap : IEntityTypeConfiguration<ProdutoCosif>
    {
        public void Configure(EntityTypeBuilder<ProdutoCosif> modelBuilder)
        {
            modelBuilder.ToTable("PRODUTO_COSIF");
            modelBuilder
                .HasKey(x => new { x.CodigoProduto, x.CodigoProdutoCosif });
            
            modelBuilder
                .Property(x => x.CodigoProduto)
                .HasColumnType("char(4)")
                .HasColumnName("COD_PRODUTO");

            modelBuilder
                .Property(x => x.CodigoProdutoCosif)
                .HasColumnType("char(11)")
                .HasColumnName("COD_COSIF");
            
            modelBuilder
                .Property(x => x.CodigoClassificacao)
                .HasColumnType("char(6)")
                .HasColumnName("COD_CLASSIFICACAO");
            
            modelBuilder
                .Property(x => x.Status)
                .HasColumnType("char(1)")
                .HasColumnName("STA_STATUS");
        }
    }
}