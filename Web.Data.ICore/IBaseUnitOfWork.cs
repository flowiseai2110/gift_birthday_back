using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.ICore
{
    public interface IBaseUnitOfWork : IDisposable
    {
        IContext Context { get; }
        int Commit(bool autoHistory = false);
        Task<int> CommitAsync(bool autoHistory = false);

        Task<IList<T>> SqlQueryList<T>(string sql, params object[] parameters) where T : class;
        Task<T> SqlQuery<T>(string sql, params object[] parameters) where T : class;
        Task<int> Exec(string sql, params object[] parameters);
    }

}
