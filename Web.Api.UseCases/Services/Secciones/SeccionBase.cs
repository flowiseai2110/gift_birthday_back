using Newtonsoft.Json;
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto;
using Web.Api.Dto.Services.Secciones;
using Web.Api.Entidades.Core.Secciones;
using Web.Api.Interface;
using Web.Data.ICore;

namespace Web.Api.UseCases.Services.Secciones
{
    public class SeccionBase
    {
        private readonly IUnitOfWork _unitOfWork;
       
        private readonly IContext _context;

        public SeccionBase(IUnitOfWork unitOfWork
            
            )
        {
            this._unitOfWork = unitOfWork;
            
            this._context = unitOfWork.Context;
        }
        public virtual async Task<StatusResponse<ValidacionResponse>> Validate(Seccion seccionData,
            ParticipanteToken participante,
            bool cumpleDatos)
        {
            var response = new StatusResponse<ValidacionResponse>();

            return response;
        }

        public virtual async Task After(StatusResponse<SeccionSaveResponse> saveResponse, ParticipanteToken participante)
        {

        }
    }
}
