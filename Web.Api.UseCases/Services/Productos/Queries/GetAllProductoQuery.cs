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
    public class GetAllProductoQuery : IRequest<IEnumerable<ProductoDto>>
    {
        public int empresaId { get; set; }
        public int localComercialId { get; set; } 
    }

    public class GetAllProductoHandler : IRequestHandler<GetAllProductoQuery, IEnumerable<ProductoDto>>
    { 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IContext _context;

        public GetAllProductoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //this._context = unitOfWork.Context;
        }

        public async Task<IEnumerable<ProductoDto>> Handle(GetAllProductoQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Query<Producto>()
                    .Where(data => data.localComercialId == request.localComercialId)
                    .ProjectTo<ProductoDto>(_mapper.ConfigurationProvider);
  
            var result = await query.ToListAsync();

            return result;
        }
    }
}
