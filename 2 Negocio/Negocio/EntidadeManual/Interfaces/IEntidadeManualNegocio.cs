using System.Collections.Generic;
using Negocio.Dominio.ViewModels;

namespace Negocio.EntidadeManual
{
    public interface IEntidadeManualNegocio
    {
        List<EntidadeManualExibirViewModel> Listar();
        bool Add(EntidadeManualViewModel produto);
    }
}