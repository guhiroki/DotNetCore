using System.Collections.Generic;
using Negocio.Dominio.ViewModels;

namespace Negocio.ProdutoCosif
{
    public interface IProdutoCosifNegocio
    {
        List<DropDownViewModel> Listar(string codigoProduto);
    }
}