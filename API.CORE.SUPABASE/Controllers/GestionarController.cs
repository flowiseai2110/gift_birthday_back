using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.UseCases.Services.Cartillas.Command;
using Web.Api.UseCases.Services.Cartillas.Queries;
using Web.Api.UseCases.Services.Clientes.Command;
using Web.Api.UseCases.Services.Clientes.Queries;
using Web.Api.UseCases.Services.LocalesComerciales.Command;
using Web.Api.UseCases.Services.LocalesComerciales.Queries;
using Web.Api.UseCases.Services.Promociones.Command;
using Web.Api.UseCases.Services.Promociones.Queries;
using Web.Api.UseCases.Services.Usuarios.Command;
using Web.Api.UseCases.Services.Usuarios.Queries;

namespace WEB.API.ECOMMERCE.Controllers
{
    public class GestionarController : Controller
    {
        private readonly IMediator _mediator;

        public GestionarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("guardarLocalComercial")]
        public async Task<IActionResult> guardarLocalComercial([FromBody] CreateLocalComercialCommand createCommand)
        {
            var responde = await _mediator.Send(createCommand);
            return Ok(responde);
        }

        [HttpPost("listarLocalComercialDapper")]
        public async Task<IActionResult> listarLocalComercialDapper([FromBody] GetLocalComercialxEmpresaQuery getQuery)
        {
            var responde = await _mediator.Send(getQuery);
            return Ok(responde);
        }
        [HttpPost("listarLocalComercialEF")]
        public async Task<IActionResult> listarLocalComercialEF([FromBody] GetLocalComercialxEmpresa2Query getQuery)
        {
            var responde = await _mediator.Send(getQuery);
            return Ok(responde);
        }
        [HttpPost("guardarUsuario")]
        public async Task<IActionResult> guardarUsuario([FromBody] CreateUsuarioCommand createCommand)
        {
            var responde = await _mediator.Send(createCommand);
            return Ok(responde);
        }

        [HttpPost("listarUsuario")]
        public async Task<IActionResult> listarUsuario([FromBody] GetAllUsuarioQuery getQuery)
        {
            var responde = await _mediator.Send(getQuery);
            return Ok(responde);
        }

        [HttpPost("guardarPromocion")]
        public async Task<IActionResult> guardarPromocion([FromBody] CreatePromocionCommand createCommand)
        {
            var responde = await _mediator.Send(createCommand);
            return Ok(responde);
        }

        [HttpPost("listarPromocion")]
        public async Task<IActionResult> listarPromocion([FromBody] GetAllPromocionQuery getQuery)
        {
            var responde = await _mediator.Send(getQuery);
            return Ok(responde);
        }

        [HttpPost("guardarCliente")]
        public async Task<IActionResult> guardarCliente([FromBody] CreateClienteCommand createCommand)
        {
            var responde = await _mediator.Send(createCommand);
            return Ok(responde);
        }

        [HttpPost("listarCliente")]
        public async Task<IActionResult> listarCliente([FromBody] GetAllClienteQuery getQuery)
        {
            var responde = await _mediator.Send(getQuery);
            return Ok(responde);
        }

        [HttpPost("guardarCartilla")]
        public async Task<IActionResult> guardarCartilla([FromBody] CreateCartillaCommand createCommand)
        {
            var responde = await _mediator.Send(createCommand);
            return Ok(responde);
        }

        [HttpPost("listarCartilla")]
        public async Task<IActionResult> listarCartilla([FromBody] GetAllCartillaQuery getQuery)
        {
            var responde = await _mediator.Send(getQuery);
            return Ok(responde);
        }
    }
}
