using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.config;
using Web.Api.Dto.Gestionar;

namespace Web.Api.Interface.Persistence.Promocion
{
    public interface ILocalComercialRepository:IGenericRepository<LocalComercial>
    {
       Task<IEnumerable<LocalComercialResponseDto>> GetLocalxEmpresa(int param_i_empresa_id);
       Task<IEnumerable<LocalComercialResponseDto>> GetLocalxEmpresaxQuery(int param_empresa_id);
    }
}
