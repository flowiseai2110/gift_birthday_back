using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Gestionar;
using Web.Api.Dto.Services.Productos;

namespace Web.Api.Interface.UseCases.Servicios.GiftBithDay
{
    public interface ISupaUsuarioService
    {
        public Task<IEnumerable<UsuarioSupabaseDto>> GetUsuario();
    }
}
