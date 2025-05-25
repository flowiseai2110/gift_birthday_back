
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto;
using Web.Api.Dto.Services.Secciones;
using Web.Api.Entidades.Core.Secciones;
using Web.Api.UseCases.Services.Plugins;


namespace Web.Api.UseCases.Services.Secciones
{
    public interface ISeccion : IPlugin
    {
        Task<StatusResponse<SeccionResponse>> Get(Seccion request, ParticipanteToken participante);
        Task<StatusResponse<SeccionSaveResponse>> Save(Seccion request, ParticipanteToken participante);
        Task<StatusResponse<ValidacionResponse>> Validate(Seccion request,
            ParticipanteToken participante,
            bool cumpleData);
        Task After(StatusResponse<SeccionSaveResponse> saveResponse, ParticipanteToken participante);
        
    }
}
