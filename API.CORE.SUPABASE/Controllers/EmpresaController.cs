using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Interface.UseCases.Servicios.Empresas;
using Web.Api.UseCases.Services.Empresas.Command;
using Web.Api.UseCases.Services.Empresas.Queries;

namespace WEB.API.ECOMMERCE.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IEmpresaService _empresa;
        public EmpresaController(IMediator mediator, IEmpresaService empresa)
        {
            _mediator = mediator;
            _empresa = empresa;
        }
        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] CreateEmpresaCommand createEmpresaCommand)
        {
            var responde = await _mediator.Send(createEmpresaCommand);
            return Ok(responde);
        }

        [HttpPost("listarEmpresa")]
        public async Task<IActionResult> Listar([FromBody] GetUsuariosQuery GetEmpresa)
        { 
            //var responde = await _mediator.Send(GetEmpresa);
            var responde = await _empresa.listar();
            return Ok(responde);
        }
    }
}
