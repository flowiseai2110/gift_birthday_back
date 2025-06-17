using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Web.Api.Interface.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<Int32> CreateAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public T? GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync(T entity);

    }
}
