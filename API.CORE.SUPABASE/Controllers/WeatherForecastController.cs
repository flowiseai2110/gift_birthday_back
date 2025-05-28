using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Domain.Entities;
using Web.Api.Interface.Persistence.GiftBirthDay;
using Web.Api.Interface.UseCases.Servicios.Empresas;
using Web.Api.UseCases.Services.GiftBirthDay;
using Web.Api.UseCases.Services.GiftBirthDay.Queries;
using HtmlAgilityPack;
using API.CORE.SUPABASE;


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

        [HttpGet("web_externa")]
        public async Task<IActionResult> GetWebExterna()
        {
            var responde = await new ScrapearWeb().ScrapeProductosAsync();
            
            return Ok(responde);
        }

        
    } 
 
}
