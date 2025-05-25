using MassTransit;
using Newtonsoft.Json;
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto;
using Web.Api.Dto.Services.Productos;
using Web.Api.Entidades.Core.Secciones;
using Web.Api.Interface; 
using Web.Api.Interface.UseCases.Servicios.Productos;
 

namespace Web.Api.UseCases.Services.Secciones.Producto
{
    public class ProductoImagenSeccion : SeccionBase, ISeccion
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoService _productoService;
        public ProductoImagenSeccion(IProductoService productoService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._productoService = productoService;
            _unitOfWork = unitOfWork;
        }

        public async Task<StatusResponse<SeccionResponse>> Get(Seccion request, ParticipanteToken participante)
        {
            var response = new StatusResponse<SeccionResponse>();

            var lista = await _productoService.ListarProductoImagen();
            response.Data = new SeccionResponse
            {
                isValid = true,
                body = lista
            };
            return response;
        }

        public async Task<StatusResponse<SeccionSaveResponse>> Save(Seccion request, ParticipanteToken participante)
        {
            var response = new StatusResponse<SeccionSaveResponse>();
            var data = JsonConvert.DeserializeObject<ProductoImagenDto>(request.body);
            var result = await _productoService.GuardarProductoImagen(data);

            response.Messages.Add("Ok");
            response.Success = result;
            return response;
        }

    }
}
