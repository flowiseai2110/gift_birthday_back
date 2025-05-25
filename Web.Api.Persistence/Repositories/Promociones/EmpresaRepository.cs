using Dapper;
using Microsoft.Extensions.Caching.Distributed;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using Web.Api.Domain.Entities.config;
using Web.Api.Dto.Gestionar;
using Web.Api.Interface.Infraestructure;
using Web.Api.Interface.Persistence.Promocion; 
using Web.Api.Persistence.Context.Promocion;

namespace Web.Api.Persistence.Repositories.Promociones
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly PromocionContext _efContext;
        private readonly DapperPromocionContext _dapperContext;
        private readonly IEventBus _eventBus;
        private readonly IDistributedCache _distributedCache;
        public EmpresaRepository(PromocionContext applicationContext, DapperPromocionContext dapper, IEventBus eventbus, IDistributedCache distributedCache)
        {
            _efContext = applicationContext;
            _dapperContext = dapper;
            _eventBus = eventbus;
            _distributedCache = distributedCache;
        }

        public async Task<int> CreateAsync(Empresa entity)
        {
            entity.fechaRegistro = DateTime.UtcNow;
            entity.activo = true;

            _efContext.Empresa.Add(entity);
            var result = await _efContext.SaveChangesAsync();

            //if(result > 0)
            //{
            //    var empresaDto=new EmpresaDto();
            //    empresaDto.empresa_id = entity.empresa_id;
            //    var personaCreatedEventBus = entity;
            //    _eventBus.Publish(empresaDto);

            //}
            return entity.empresa_id;
        }

        public async Task<IEnumerable<Empresa>> GetAllAsync(Empresa entity)
        {
            //var cacheKey = "empresaCache";
            //var redisEmpresas = await _distributedCache.GetAsync(cacheKey);
            //if (redisEmpresas != null)
            //{
            //    return JsonSerializer.Deserialize<IEnumerable<Empresa>>(redisEmpresas);
            //}

            //using var connection = _dapperContext.CreateConnection();
            //var query = @"select e.i_empresa_id ,e.v_razon_social ,e.v_ruc ,e.v_direccion ,e.v_telefono_principal ,e.v_celular_principal  from config.empresa e  where e.b_activo = true order by v_razon_social asc";

            //var result = await connection.QueryAsync<Empresa>(query, new {}, commandType: CommandType.Text);

             var result = _efContext.Empresa.Where(x => x.empresa_id == entity.empresa_id || entity.empresa_id == 0 );
             

            //var serializedEmpresas = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(result));
            //var options = new DistributedCacheEntryOptions()
            //    .SetAbsoluteExpiration(DateTime.Now.AddHours(8))
            //    .SetSlidingExpiration(TimeSpan.FromMinutes(60));

            //await _distributedCache.SetAsync(cacheKey, serializedEmpresas, options);

            return result;
        }

        public Empresa? GetByIdAsync(int id)
        {
            var result = _efContext.Empresa.Where(x => x.empresa_id == id);

            return result.FirstOrDefault();
        }
         
        public bool UpdateAsync(Empresa entity)
        {
            var empresa = _efContext.Empresa.Where(x => x.ruc == entity.ruc).FirstOrDefault();
            empresa.razon_social = entity.razon_social;
            empresa.direccion = entity.direccion;
            empresa.celular_principal = entity.celular_principal;
            empresa.telefono_principal = entity.telefono_principal;
            
            _efContext.Update(empresa);
            
            return true;
        }
    }
}
