
using Negocio.Produto;
using Negocio.ProdutoCosif;
using Negocio.EntidadeManual;
using Infraestrutura.Dados;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.IoC
{
    public static class InjecaoDeDependencia
    {
        public static void Registrar(IServiceCollection servico) 
        {
            servico.AddDbContext<MovimentosManuaisContext>(
                options => options.UseSqlServer("Persist Security Info=False;User ID=SA;Password=Mssql@12345;Initial Catalog=TestItau;Server=localhost"));
            servico.AddScoped<IProdutoNegocio, ProdutoNegocio>();
            servico.AddScoped<IProdutoCosifNegocio, ProdutoCosifNegocio>();
            servico.AddScoped<IEntidadeManualNegocio, EntidadeManualNegocio>();
        } 
    }
}

