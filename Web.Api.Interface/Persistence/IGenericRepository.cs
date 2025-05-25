using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Web.Api.Interface.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<Int32> CreateAsync(T entity);
        bool UpdateAsync(T entity);
         T? GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(T entity);

    }
}
