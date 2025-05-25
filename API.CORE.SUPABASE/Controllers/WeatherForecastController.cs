using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Interface.Persistence.GiftBirthDay;
using Web.Api.Interface.UseCases.Servicios.Empresas;
using Web.Api.UseCases.Services.GiftBirthDay;
using Web.Api.UseCases.Services.GiftBirthDay.Queries;

namespace WEB.API.ECOMMERCE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WeatherForecastController(IMediator mediator)  
        {
            _mediator = mediator;

        }  
        [HttpGet("personas")]
        public async Task<IActionResult> GetPersonas()
        {
            var responde = await _mediator.Send(new GetUsuariosQuery());

            return Ok(responde);
        }
    }
}
