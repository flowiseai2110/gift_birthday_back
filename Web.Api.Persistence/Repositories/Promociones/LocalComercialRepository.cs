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
using static Dapper.SqlMapper;

namespace Web.Api.Interface.Persistence.Promociones
{
    public class LocalComercialRepository : ILocalComercialRepository
    {
        private readonly PromocionContext _efContext;
        private readonly DapperPromocionContext _dapperContext;

        public LocalComercialRepository(PromocionContext efContext, DapperPromocionContext dapperContext)
        {
            _efContext = efContext;
            _dapperContext = dapperContext;
        }

        public async Task<int> CreateAsync(LocalComercial entity)
        {
            entity.fechaRegistro = DateTime.UtcNow;
            entity.activo = true;
            _efContext.LocalComercial.Add(entity);
            await _efContext.SaveChangesAsync();

            return entity.local_comercial_id;
        }

        public async Task<IEnumerable<LocalComercial>> GetAllAsync(LocalComercial entity)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = @"SELECT i_local_comercial_id, v_nombre_comercial, v_direccion, v_telefono_principal, v_celular_principal, t_hora_inicio, t_hora_fin, v_tipo_horario, b_activo, v_usuario_registro, d_fecha_registro, v_usuario_modificacion, d_fecha_modificacion FROM config.local_comercial where i_empresa_id = @i_empresa_id";

            var result = await connection.QueryAsync<LocalComercial>(query, new { i_empresa_id = entity.empresa_id }, commandType: CommandType.Text);

            return result;
        }
        public async Task<IEnumerable<LocalComercialResponseDto>> GetLocalxEmpresa(int param_empresa_id)
        {
            //using var connection = _dapperContext.CreateConnection();
            //var query = @"SELECT i_local_comercial_id as local_comercial_id, v_nombre_comercial as nombre_comercial, v_direccion as direccion, v_telefono_principal telefono_principal, v_celular_principal as celular_principal, t_hora_inicio as hora_inicio, t_hora_fin as hora_fin, v_tipo_horario as tipo_horario, v_usuario_registro as usuario_registro, d_fecha_registro as fecha_registro FROM config.local_comercial where i_empresa_id = @i_empresa_id";

            //var result = await connection.QueryAsync<LocalComercialDto>(query, new { i_empresa_id = param_i_empresa_id }, commandType: CommandType.Text);
             var query = from p in _efContext.Empresa
                                   join l in _efContext.LocalComercial
                                   on p.empresa_id equals l.empresa_id
                                   where p.empresa_id == param_empresa_id
                         select new LocalComercialResponseDto
                         {
                                       local_comercial_id = l.local_comercial_id,
                                       empresa_id = p.empresa_id,
                                       nombre_comercial = l.nombre_comercial,
                                       direccion = l.direccion,
                                       telefono_principal = l.telefono_principal,
                                       celular_principal = l.celular_principal,
                                       NombreEmpresa = p.razon_social
                                   };
            return query;
        }
        public async Task<IEnumerable<LocalComercialResponseDto>> GetLocalxEmpresaxQuery(int param_empresa_id)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = @"SELECT   l.i_local_comercial_id as local_comercial_id, 
	                               l.v_nombre_comercial as nombre_comercial, 
	                               e.v_razon_social as NombreEmpresa,
	                               l.v_direccion as direccion, 
	                               l.v_telefono_principal telefono_principal, 
	                               l.v_celular_principal as celular_principal, 
	                               l.t_hora_inicio as hora_inicio, 
	                               l.t_hora_fin as hora_fin, 
	                               l.v_tipo_horario as tipo_horario, 
	                               l.v_usuario_registro as usuario_registro, 
	                               l.d_fecha_registro as fecha_registro
                            FROM config.local_comercial l
                            inner join config.empresa e  on e.i_empresa_id  = l.i_empresa_id 
                            where l.i_empresa_id = @i_empresa_id"
                         ;

            var result = await connection.QueryAsync<LocalComercialResponseDto>(query, new { i_empresa_id = param_empresa_id }, commandType: CommandType.Text);
            //var query = from p in _efContext.Empresa
            //            join l in _efContext.LocalComercial
            //            on p.empresa_id equals l.empresa_id
            //            where p.empresa_id == param_empresa_id
            //            select new LocalComercialResponseDto
            //            {
            //                local_comercial_id = l.local_comercial_id,
            //                empresa_id = p.empresa_id,
            //                nombre_comercial = l.nombre_comercial,
            //                direccion = l.direccion,
            //                telefono_principal = l.telefono_principal,
            //                celular_principal = l.celular_principal,
            //                NombreEmpresa = p.razon_social
            //            };
            return result;
        }

        public LocalComercial? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(LocalComercial entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocalComercialResponseDto> obtenerLocalesComercialesxEmpresa(int empresa_id)
        {
            var query = from p in _efContext.Empresa
                        join l in _efContext.LocalComercial
                        on p.empresa_id equals l.empresa_id
                        where p.empresa_id == empresa_id
                        select new LocalComercialResponseDto
                        {
                            local_comercial_id = l.local_comercial_id,
                            empresa_id = p.empresa_id,
                            nombre_comercial = l.nombre_comercial,
                            direccion = l.direccion,
                            telefono_principal = l.telefono_principal,
                            celular_principal = l.celular_principal,
                            NombreEmpresa = p.razon_social
                        };

            return query;
        }
    }
}
