using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Gestionar;
using Web.Api.Interface;
using Web.Api.Interface.UseCases.Servicios.Empresas;
using Web.Api.UseCases.Services.Empresas.Queries;

namespace Web.Api.UseCases.Services.Empresas
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public EmpresaService(IMediator mediator, IUnitOfWork unitOfWork) {
            this._mediator = mediator;
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EmpresaDto>> listar() 
        {
            var empresas = await _mediator.Send(new GetAllEmpresaQuery
            {
                ruc = ""
            });

            return empresas;
        }
    }
}
