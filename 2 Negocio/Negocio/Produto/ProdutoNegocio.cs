using System.Collections.Generic;
using System.Linq;
using Infraestrutura.Dados;
using Negocio.Dominio.ViewModels;

namespace Negocio.Produto
{
    public class ProdutoNegocio : IProdutoNegocio
    {
        private readonly MovimentosManuaisContext contexto;
        public ProdutoNegocio(MovimentosManuaisContext _contexto)
        {
            contexto = _contexto;
        }
        public List<DropDownViewModel> Listar()
        {
            var resposta = contexto.Produtos.Select(p => new DropDownViewModel {
                Codigo = p.CodigoProduto,
                Descricao = p.DescricaoProduto
            });
            return resposta.ToList();
        }
    }
}