using LinqToDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Web.Data.ICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Web.Data.Core
{
    public class ContextAdapter : IContext, IDisposable
    {
        private readonly Guid _instanceId;
        private readonly IDbContext _context;
        private bool _disposed;

        public ContextAdapter(IDbContext context)
        {
            this._instanceId = Guid.NewGuid();
            this._context = context;
        }

        protected IDbContext Context
        {
            get
            {
                return this._context;
            }
        }

        public Guid InstanceId
        {
            get
            {
                return this._instanceId;
            }
        }

        public int? Timeout { get; set; }

        public DatabaseFacade Database
        {
            get
            {
                return this._context.Database;
            }
        }

        public virtual T Add<T>(T entity) where T : class
        {
            return this._context.Set<T>().Add(entity).Entity;
        }

        public virtual void Add<T>(IEnumerable<T> entities) where T : class
        {
            foreach (T entity in entities)
                this._context.Set<T>().Add(entity);
        }

        public virtual T Find<T>(params object[] keys) where T : class
        {
            return this._context.Set<T>().Find(keys);
        }

        public virtual T GetById<T>(long id) where T : class
        {
            return this._context.Set<T>().Find((object)id);
        }

        public virtual T GetById<T>(int id) where T : class
        {
            return this._context.Set<T>().Find((object)id);
        }

        public virtual T GetById<T>(string id) where T : class
        {
            return this._context.Set<T>().Find((object)id);
        }

        public virtual IQueryable<T> Query<T>(bool asNoTracking = true) where T : class
        {
            return !asNoTracking ? (IQueryable<T>)this._context.Set<T>() : this._context.Set<T>().AsNoTracking<T>();
        }

        public virtual void Remove<T>(T entity) where T : class
        {
            this._context.Entry<T>(entity).State = EntityState.Deleted;
            this._context.Set<T>().Remove(entity);
        }

        public virtual void Update<T>(T entity) where T : class
        {
            EntityEntry<T> entityEntry = this._context.Entry<T>(entity);
            this._context.Set<T>().Attach(entity);
            entityEntry.State = EntityState.Modified;
        }

        public virtual void Update<T>(T entity, params Expression<Func<T, object>>[] properties) where T : class
        {
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));
            this._context.Set<T>().Attach(entity);
            if (((IEnumerable<Expression<Func<T, object>>>)properties).Any<Expression<Func<T, object>>>())
            {
                EntityEntry<T> entityEntry = this._context.Entry<T>(entity);
                foreach (Expression<Func<T, object>> property in properties)
                    entityEntry.Property<object>(property).IsModified = true;
            }
            else
                this._context.Entry<T>(entity).State = EntityState.Modified;
        }

        public virtual T GetSingle<T>(Expression<Func<T, bool>> predicate, bool asNoTracking = true) where T : class
        {
            return !asNoTracking ? this._context.Set<T>().FirstOrDefault<T>(predicate) : this._context.Set<T>().AsNoTracking<T>().FirstOrDefault<T>(predicate);
        }

        public virtual T GetSingle<T>(
          Expression<Func<T, bool>> predicate,
          bool asNoTracking = true,
          params Expression<Func<T, object>>[] includeProperties)
          where T : class
        {
            IQueryable<T> source = asNoTracking ? this._context.Set<T>().AsNoTracking<T>() : (IQueryable<T>)this._context.Set<T>();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
                source = (IQueryable<T>)source.Include<T, object>(includeProperty);
            return Queryable.FirstOrDefault<T>(source.Where<T>(predicate));
        }

        public virtual IEnumerable<T> FindBy<T>(
          Expression<Func<T, bool>> predicate,
          bool asNoTracking = true)
          where T : class
        {
            return !asNoTracking ? (IEnumerable<T>)this._context.Set<T>().Where<T>(predicate) : (IEnumerable<T>)this._context.Set<T>().AsNoTracking<T>().Where<T>(predicate);
        }

        public virtual void DeleteWhere<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            foreach (T entity in (IEnumerable<T>)this._context.Set<T>().Where<T>(predicate))
                this._context.Entry<T>(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;
            if (disposing && this._context != null)
                this._context.Dispose();
            this._disposed = true;
        }

        public IEnumerable<T> EntityFromSql<T>(string procedureName, params DataParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
