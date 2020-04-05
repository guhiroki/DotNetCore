using System;

namespace Negocio.Dominio.Entidades
{
    public class EntidadeManual : ProdutoBase
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataMovimento { get; set; }
        public string CodigoUsuario { get; set; }
        public float Valor { get; set; }


        public virtual Produto Produto { get; set; }
        public virtual ProdutoCosif ProdutoCosif { get; set; }
    }
}