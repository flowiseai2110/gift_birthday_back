using MediatR;
using Microsoft.AspNetCore.Mvc;
using Release.Helper;
using Web.Api.Entidades.Core.Secciones;
using Web.Api.UseCases.Services.Evento.Commands;
using Web.Api.UseCases.Services.Evento.Queries;
using Web.Api.UseCases.Services.GiftBirthDay.Queries;
using Web.Api.UseCases.Services.Secciones;

namespace WEB.API.ECOMMERCE.Controllers
{
    [ApiController]
    //[ValidateIpAddress]
    [Route("[controller]/[action]")]
    public class EventoController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        public EventoController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var responde = await _mediator.Send(new GetEventAllQuery());

            return Ok(responde);
        }
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveEventCommand request)
        {
            var responde = await _mediator.Send(request);

            return Ok(responde);
        }
    }
}
