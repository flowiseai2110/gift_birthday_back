using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto;
using Web.Api.Entidades.Core.Secciones;
using Web.Api.Interface;
using Web.Api.Interface.UseCases.Servicios.Empresas;

namespace Web.Api.UseCases.Services.Secciones.Empresa
{
    public class EmpresaSeccion : SeccionBase, ISeccion
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmpresaService empresaService;
        public EmpresaSeccion(IEmpresaService empresaService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.empresaService = empresaService;
            _unitOfWork = unitOfWork;
        }

        public async Task<StatusResponse<SeccionResponse>> Get(Seccion request, ParticipanteToken participante)
        {
            var response = new StatusResponse<SeccionResponse>();

            var lista = await empresaService.listar();
            response.Data = new SeccionResponse
            {
                isValid = false,
                body = lista
            };
            return response;
        }

        public Task<StatusResponse<SeccionSaveResponse>> Save(Seccion request, ParticipanteToken participante)
        {
            throw new NotImplementedException();
        }
    }
}
