using MediatR; 
using Web.Api.Dto.Services.Productos;
using Web.Api.Interface;
using Web.Api.Interface.UseCases.Servicios.Productos; 
using Web.Api.UseCases.Services.Productos.Commands;
using Web.Api.UseCases.Services.Productos.Queries;

namespace Web.Api.UseCases.Services.Productos
{
    public class ProductoService:IProductoService
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public ProductoService(IMediator mediator, IUnitOfWork unitOfWork)
        {
            this._mediator = mediator;
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ProductoDto>> ListarProducto()
        {
            var productos = await _mediator.Send(new GetAllProductoQuery
            {
                empresaId = 0,
                localComercialId = 2
            });

            return productos;
        }

        public async Task<bool> GuardarProducto(ProductoDto productoDto) {

            var result = await _mediator.Send(new SaveCommand
            { 
                dataDto = productoDto
            });

            return result;
        }
        public async Task<IEnumerable<ProductoImagenDto>> ListarProductoImagen()
        {
            var productos = await _mediator.Send(new GetAllProductoImagenQuery
            {
                 productoId = 8,
            });

            return productos;
        }

        public async Task<bool> GuardarProductoImagen(ProductoImagenDto productoImagenDto)
        {

            var result = await _mediator.Send(new SaveImagenCommand
            {
                dataDto = productoImagenDto
            });

            return result;
        }
    }
}
