using MediatR;
using Microsoft.AspNetCore.Mvc; 
using Web.Api.UseCases.Services.Productos.Commands;
using Web.Api.UseCases.Services.Productos.Queries; 

namespace WEB.API.ECOMMERCE.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IMediator _mediator; 
        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Producto")]
        public async Task<IActionResult> Guardar([FromBody] SaveCommand createProductoCommand)
        {
            var responde = await _mediator.Send(createProductoCommand);

            return Ok(responde);
        }

        [HttpPost("Listar")]
        public async Task<IActionResult> Listar([FromBody] GetAllProductoQuery GetProducto)
        { 
            var responde = await _mediator.Send(GetProducto);
              
            return Ok(responde);
        }
    }
}
