using AutoMapper;
using FluentValidation;
using MediatR;
using Web.Api.Domain.Entities;
using Web.Api.Domain.Entities.config;
using Web.Api.Dto.Gestionar;
using Web.Api.Dto.Gestionar.Productos;
using Web.Api.Interface.Persistence;

namespace Web.Api.UseCases.Services.Empresas.Command
{
    public sealed class CreateEmpresaHandler : IRequestHandler<CreateEmpresaCommand, EmpresaDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CreateEmpresaValidator _validatorRules;
        public CreateEmpresaHandler(IUnitOfWork unitOfWork, IMapper mapper, CreateEmpresaValidator validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validatorRules = validator;
        }
        public async Task<EmpresaDto> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
        {
            await _validatorRules.ValidateAndThrowAsync(request, cancellationToken);

            var response = new EmpresaDto();

            //var empresa = MapperEmpresa(request);
            var empresa = _mapper.Map<Empresa>(request); 
            empresa.activo = true;
            empresa.fechaRegistro = DateTime.UtcNow;

            var result = await _unitOfWork.Empresa.CreateAsync(empresa);
            response.empresa_id = result;
            return response;
        }
         
    }
}
