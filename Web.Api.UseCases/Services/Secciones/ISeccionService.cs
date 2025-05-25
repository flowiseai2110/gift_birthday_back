 
using Release.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Entidades.Core.Secciones;

namespace Web.Api.UseCases.Services.Secciones
{
    public interface ISeccionService
    {
        Task<StatusResponse> Get(SeccionRequest request);
        Task<StatusResponse> Save(SeccionSaveRequest request);
    }
}
