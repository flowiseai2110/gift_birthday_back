using Microsoft.AspNetCore.Mvc;
using Release.Helper;
using Web.Api.Entidades.Core.Secciones;
using Web.Api.UseCases.Services.Secciones;

namespace WEB.API.ECOMMERCE.Controllers
{
    [ApiController]
    //[ValidateIpAddress]
    [Route("[controller]/[action]")]
    public class SeccionesController : ControllerBase
    {
        private readonly ISeccionService _seccionService;

        public SeccionesController(ISeccionService seccionService)
        {
            this._seccionService = seccionService;
        }
        [HttpPost]
        public async Task<StatusResponse> Get([FromBody] SeccionRequest request)
        {
            return await _seccionService.Get(request);
        }
        [HttpPost]
        public async Task<StatusResponse> Save([FromBody] SeccionSaveRequest request)
        {
            return await _seccionService.Save(request);
        }
    }
}
