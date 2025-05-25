using AutoMapper;
using MediatR;
using Web.Api.Domain.Entities;
using Web.Api.Dto.Gestionar;
using Web.Api.Interface;
using Web.Api.UseCases.Services.Productos;
using Web.Api.Domain.Entities.config;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Web.Api.UseCases.Common.Bases;
using Web.Data.ICore;
using LinqToDB;

namespace Web.Api.UseCases.Services.Empresas.Queries
{
    public record class GetAllEmpresaQuery : IRequest<IEnumerable<EmpresaDto>>
    {
        public string ruc { get; set; }
    }

    public class GetAllEmpresaHandler : IRequestHandler<GetAllEmpresaQuery, IEnumerable<EmpresaDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IContext _context;

        public GetAllEmpresaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = _unitOfWork.Context;
        }

        public async Task<IEnumerable<EmpresaDto>> Handle(GetAllEmpresaQuery request, CancellationToken cancellationToken)
        { 
            var result = await _context.Query<Empresa>().ToListAsync();

            var query = _mapper.Map<IEnumerable<EmpresaDto>>(result);
             

            return query;

        }
    }
}
