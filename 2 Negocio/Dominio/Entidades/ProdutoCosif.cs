using System;

namespace Negocio.Dominio.Entidades
{
    public class ProdutoCosif : ProdutoBase
    {
        public string CodigoClassificacao { get; set; }
        public char Status { get; set; }

        public virtual Produto Produto { get; set; }
    }
}