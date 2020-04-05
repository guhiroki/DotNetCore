using Negocio.Dominio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Negocio.ProdutoCosif;

namespace Apresentacao.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoCosifController : ControllerBase
    {
        private readonly IProdutoCosifNegocio _entidadeManualNegocio;
        public ProdutoCosifController(IProdutoCosifNegocio entidadeManualNegocio)
        {
            _entidadeManualNegocio = entidadeManualNegocio;
        }

        [HttpGet("codigoProduto")]
        public ActionResult<List<DropDownViewModel>> GetEntidadeManual(string codigoProduto)
        {
            var entidadesManuais = _entidadeManualNegocio.Listar(codigoProduto);
            return entidadesManuais;
        }
    }
}