using Infraestrutura.Dados.Mapeamento;
using Microsoft.EntityFrameworkCore;
using Negocio.Dominio.Entidades;

namespace Infraestrutura.Dados
{
    public class MovimentosManuaisContext : DbContext
    {
        public MovimentosManuaisContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoCosif> ProdutosCosif { get; set; }
        public DbSet<EntidadeManual> EntidadesManuais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ProdutoCosifMap());
            modelBuilder.ApplyConfiguration(new EntidadeManualMap());
        }
    }
}