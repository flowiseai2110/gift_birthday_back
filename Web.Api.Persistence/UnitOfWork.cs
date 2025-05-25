using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Core;
using Web.Api.Interface;

namespace Web.Api.Persistence
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        private readonly IDbContext _ctx;
        public UnitOfWork(IDbContext ctx)
              : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
