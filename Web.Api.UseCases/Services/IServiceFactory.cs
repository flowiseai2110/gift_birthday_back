using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.UseCases.Services
{

    public interface IServiceFactory
    {
        IService<R> GetService<T, R>() where T : class;
    }
}
