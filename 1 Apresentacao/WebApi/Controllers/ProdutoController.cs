using Negocio.Produto;
using Negocio.Dominio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Apresentacao.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoNegocio _produtoNegocio;
        public ProdutoController(IProdutoNegocio produtoNegocio)
        {
            _produtoNegocio = produtoNegocio;
        }

        [HttpGet]
        public ActionResult<List<DropDownViewModel>> GetEntidadeManual()
        {
            var dropDownProdutos = _produtoNegocio.Listar();
            return dropDownProdutos;
        }
    }
}