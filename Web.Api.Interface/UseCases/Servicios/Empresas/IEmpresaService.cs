using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Gestionar;


namespace Web.Api.Interface.UseCases.Servicios.Empresas
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaDto>> listar();
    }
}
