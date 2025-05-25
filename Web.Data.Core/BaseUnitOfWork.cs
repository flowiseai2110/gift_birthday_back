using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data.ICore;

namespace Web.Data.Core
{
    public class BaseUnitOfWork : IBaseUnitOfWork, IDisposable
    {      
        private IDbContext _ctx;
        private readonly Dictionary<Type, object> _container;

        public BaseUnitOfWork(IDbContext ctx)
        {
            this._container = new Dictionary<Type, object>();
            this._ctx = ctx;
        }

        public IContext Context
        {
            get
            {
                if (this._container.Keys.Contains<Type>(typeof(IContext)))
                    return this._container[typeof(IContext)] as IContext;
                ContextAdapter contextAdapter = new ContextAdapter(this._ctx);
                this._container.Add(typeof(IContext), (object)contextAdapter);
                return (IContext)contextAdapter;
            }
        }
        public int Commit(bool autoHistory = true)
        {
            //if (autoHistory) _ctx.EnsureAutoHistoryExtension();
            //return _ctx.SaveChanges();
            var save = _ctx.SaveChanges();
            if (autoHistory && save > 0) _ctx.EnsureAutoHistoryExtension();
            return save;
        }

        public async Task<int> CommitAsync(bool autoHistory = true)
        {
            if (autoHistory) await _ctx.EnsureAutoHistoryExtension();
            return await _ctx.SaveChangesAsync();
            //var save = await _ctx.SaveChangesAsync();
            //if(autoHistory && save > 0) await _ctx.EnsureAutoHistoryExtension();
            //return save;
        }

        public void Dispose()
        {
            _ctx.Dispose();        
        }

        public async Task<IList<T>> SqlQueryList<T>(string sql, params object[] parameters) where T : class
        {        
            return await _ctx.Set<T>().FromSqlRaw(sql, parameters).ToListAsync();
        }

        public async Task<T> SqlQuery<T>(string sql, params object[] parameters) where T : class
        {
            return (await _ctx.Set<T>().FromSqlRaw(sql, parameters).ToListAsync()).FirstOrDefault();            
        }
        public async Task<int> Exec(string sql, params object[] parameters)
        {
            return await _ctx.Database.ExecuteSqlRawAsync(sql,parameters);
        }
   
    }
}
