using Dapper; 
using System.Data; 
using Web.Api.Domain.Entities;
using Web.Api.Dto.Gestionar.Productos;
using Web.Api.Interface.Persistence;
using Web.Api.Persistence.Context;

namespace Web.Api.Persistence.Repositories
{
    public class ProductoDapperRepository 
    {
        private readonly ApplicationContext _efContext;
        private readonly DapperContext _dapperContext;
        public ProductoDapperRepository(ApplicationContext applicationContext, DapperContext dapper)
        {
            _efContext = applicationContext;
            _dapperContext = dapper;
        }

        public async Task<int> CreateAsync(Producto entity)
        {
            _efContext.Producto.Add(entity);
            await _efContext.SaveChangesAsync();

            return entity.productoId;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync(Producto entity)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = @"select p.v_nombre, p.v_descripcion, p.f_precio_venta from ecommerce.producto p where p.i_producto_id  = @p_i_producto_id or p.i_producto_id = p.i_producto_id ;";

            var result = await connection.QueryAsync<Producto>(query, new { p_i_producto_id = 1 }, commandType: CommandType.Text);

            return result;
        }

        public Producto? GetByIdAsync(int id)
        {
            var result = _efContext.Producto.Where(x => x.productoId == id);

            return result.FirstOrDefault();
        }

        public Task<IEnumerable<ProductoRequestDto>> GetProductoxFiltroAsync(ProductoRequestDto entity)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Producto>> save()
        //{
        //    var nuevasEntidades = new Producto 
        //    { v_nombre = "Zapatillas",i_marca_id=1,i_categoria_id=1,
        //      i_sitio_pagina=1, 
        //      v_descripcion = "zapatillas para correr", 
        //      b_activo=true,v_usuario_registro="DIEGO",
        //      d_registro= DateTime.UtcNow 

        //    };
        //    dbContext.Producto.Add(nuevasEntidades);
        //    dbContext.SaveChanges();

        //    var resultados = dbContext.Producto.ToList();

        //    return resultados;
        //}

        public bool UpdateAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

    
    }
}
