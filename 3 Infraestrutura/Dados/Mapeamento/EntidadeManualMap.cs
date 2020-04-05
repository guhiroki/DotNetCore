using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocio.Dominio.Entidades;

namespace Infraestrutura.Dados.Mapeamento
{
    public class EntidadeManualMap : IEntityTypeConfiguration<EntidadeManual>
    {
        public void Configure(EntityTypeBuilder<EntidadeManual> modelBuilder)
        {
            modelBuilder.ToTable("MOVIMENTO_MANUAL");
            modelBuilder.HasKey(x => new { x.Mes, x.Ano, x.NumeroLancamento, x.CodigoProduto, x.CodigoProdutoCosif });
            
            modelBuilder
                .Property(x => x.Mes)
                .HasColumnType("numeric(2,0)")
                .HasColumnName("DAT_MES");

            modelBuilder
                .Property(x => x.Ano)
                .HasColumnType("numeric(4,0)")
                .HasColumnName("DAT_ANO");
            
            modelBuilder
                .Property(x => x.NumeroLancamento)
                .HasColumnType("numeric(18,0)")
                .HasColumnName("NUM_LANCAMENTO");

            modelBuilder
                .Property(x => x.CodigoProduto)
                .HasColumnType("char(4)")
                .HasColumnName("COD_PRODUTO");

            modelBuilder
                .Property(x => x.CodigoProdutoCosif)
                .HasColumnType("char(11)")
                .HasColumnName("COD_COSIF");
            
            modelBuilder
                .Property(x => x.Descricao)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .HasColumnName("DES_DESCRICAO");
            
            modelBuilder
                .Property(x => x.DataMovimento)
                .HasColumnType("smalldatetime")
                .HasColumnName("DAT_MOVIMENTO");

            modelBuilder
                .Property(x => x.CodigoUsuario)
                .HasColumnType("varchar(15)")
                .HasMaxLength(15)
                .HasColumnName("COD_USUARIO");
            
            modelBuilder
                .Property(x => x.Valor)
                .HasColumnType("numeric(18,2)")
                .HasColumnName("VAL_VALOR");
        }
    }
}