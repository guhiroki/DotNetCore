using System.Collections.Generic;
using Negocio.Dominio.ViewModels;
using Infraestrutura.Dados;
using System.Linq;

namespace Negocio.ProdutoCosif
{
    public class ProdutoCosifNegocio : IProdutoCosifNegocio
    {
        private readonly MovimentosManuaisContext contexto;
        public ProdutoCosifNegocio(MovimentosManuaisContext _contexto)
        {
            contexto = _contexto;
        }

        public List<DropDownViewModel> Listar(string codigoProduto)
        {
            var resposta = contexto.ProdutosCosif
                .Where(pc => pc.CodigoProduto == codigoProduto)
                .Select(pc => new DropDownViewModel {
                    Codigo = pc.CodigoProdutoCosif,
                    Descricao = $"{pc.CodigoProdutoCosif} - ({pc.CodigoClassificacao})"
                });

            return resposta.ToList();
        }
    }
}