using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqToDB;
using MediatR; 
using Web.Api.Domain.Entities;
using Web.Api.Dto.Services.Productos;
using Web.Api.Interface; 
using Web.Data.ICore; 

namespace Web.Api.UseCases.Services.Productos.Queries
{
    public class GetAllProductoImagenQuery : IRequest<IEnumerable<ProductoImagenDto>>
    {
        public int productoId { get; set; } 
    }

    public class GetAllProductoImagenHandler : IRequestHandler<GetAllProductoImagenQuery, IEnumerable<ProductoImagenDto>>
    { 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IContext _context;

        public GetAllProductoImagenHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //this._context = unitOfWork.Context;
        }

        public async Task<IEnumerable<ProductoImagenDto>> Handle(GetAllProductoImagenQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Query<ProductoImagen>()
                    .Where(data => data.productoId == request.productoId)
                    .ProjectTo<ProductoImagenDto>(_mapper.ConfigurationProvider);
  
            var result = await query.ToListAsync();

            return result;
        }
    }
}
