using Negocio.EntidadeManual;
using Negocio.Dominio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Apresentacao.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadeManualController : ControllerBase
    {
        private readonly IEntidadeManualNegocio _entidadeManualNegocio;
        public EntidadeManualController(IEntidadeManualNegocio entidadeManualNegocio)
        {
            _entidadeManualNegocio = entidadeManualNegocio;
        }

        [HttpGet]
        public ActionResult<List<EntidadeManualExibirViewModel>> GetEntidadeManual()
        {
            var entidadesManuais = _entidadeManualNegocio.Listar();
            return entidadesManuais;
        }
        
        [HttpPost]
        public ActionResult<bool> PostEntidadeManual(EntidadeManualViewModel entidadeManual)
        {
            return _entidadeManualNegocio.Add(entidadeManual);
        }
    }
}