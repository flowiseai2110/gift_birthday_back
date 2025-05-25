using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.config;
using Web.Api.Dto.Gestionar;
using Web.Api.Interface.Persistence.Promocion;
using Web.Api.Persistence.Context.Promocion;

namespace Web.Api.Interface.Persistence.Promociones
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PromocionContext _efContext;
        private readonly DapperPromocionContext _dapperContext;

        public UsuarioRepository(PromocionContext efContext, DapperPromocionContext dapperContext)
        {
            _efContext = efContext;
            _dapperContext = dapperContext;
        }

        public async Task<int> CreateAsync(Usuario entity)
        { 
            _efContext.Usuario.Add(entity);
            await _efContext.SaveChangesAsync();

            return entity.usuarioId;
        }
        public bool UpdateAsync(Usuario entity)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Usuario>> GetAllAsync(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Usuario? GetByIdAsync(int id)
        { 
            var result = _efContext.Usuario.Where(x => x.usuarioId == id);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsuarioxLocalComercial(int local_comercial_id)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = @"SELECT i_usuario_id as usuario_id, i_local_comercial_id as local_comercial_id, v_numero_documento as numero_documento, v_tipo_documento as tipo_documento, v_nombre as nombre, v_apellido_paterno as apellido_paterno, v_apellido_materno as apellido_materno, d_fecha_nacimiento as fecha_nacimiento, v_celular as celular, v_correo_electronico as correo_electronico, b_activo, v_usuario_registro, d_fecha_registro as fecha_registro, v_usuario_modificacion as usuario_modificacion, d_fecha_modificacion as fecha_modificacion FROM config.usuario where i_local_comercial_id = @i_local_comercial_id ";

            var result = await connection.QueryAsync<UsuarioDto>(query, new { i_local_comercial_id = local_comercial_id }, commandType: CommandType.Text);

            return result;
        }


    }
}
