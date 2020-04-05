using System.Collections.Generic;
using Negocio.Dominio.ViewModels;

namespace Negocio.Produto
{
    public interface IProdutoNegocio
    {
        List<DropDownViewModel> Listar();
    }
}