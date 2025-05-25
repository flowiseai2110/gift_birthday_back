using LinqToDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Data.Core
{
    public interface IDbContextLinq2DB
    {
        DatabaseFacade Database { get; }

        ChangeTracker ChangeTracker { get; }

        void Dispose();
        Task EnsureAutoHistoryExtension();
        EntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DbSet<T> Set<T>() where T : class;

        DataConnection GetConnection();

        

    }
}
