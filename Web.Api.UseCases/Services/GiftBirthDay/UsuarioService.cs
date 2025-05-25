using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Gestionar;
using Web.Api.Dto.Services.Productos;
using Web.Api.Interface;
using Web.Api.Interface.Persistence.GiftBirthDay;
using Web.Api.Interface.UseCases.Servicios.GiftBithDay;
using Web.Api.Interface.UseCases.Servicios.Productos;
using Web.Api.UseCases.Services.Productos.Queries;

namespace Web.Api.UseCases.Services.GiftBirthDay
{
    public class UsuarioService: ISupaUsuarioService
    {
        private readonly ISupaUsuarioRepository _supabase;
         
        public UsuarioService(ISupaUsuarioRepository repo)
        {
            this._supabase = repo;            
        }
         
        public async Task<IEnumerable<UsuarioSupabaseDto>> GetUsuario()
        { 
            return await _supabase.GetUsuario();
        }
    }
}
