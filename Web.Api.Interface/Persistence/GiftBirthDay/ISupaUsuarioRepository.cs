using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.config;
using Web.Api.Domain.Entities.proceso;
using Web.Api.Dto.Gestionar;

namespace Web.Api.Interface.Persistence.GiftBirthDay
{
    public interface ISupaUsuarioRepository  
    {
        public Task<IEnumerable<UsuarioSupabaseDto>> GetUsuario();
    }
}
