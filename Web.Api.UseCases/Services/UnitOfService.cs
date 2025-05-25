using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Interface;

namespace Web.Api.UseCases.Services
{
    public class UnitOfService : IServiceFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private Dictionary<(Type type, string name), object> _services;
        public UnitOfService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IService<R> GetService<T, R>() where T : class
        {            
            object instance = Activator.CreateInstance(typeof(T), _unitOfWork);    
            return (IService<R>) GetOrAddService(typeof(T), instance);
        }

        private object GetOrAddService(Type type, object srv)
        {
            _services ??= new Dictionary<(Type type, string Name), object>();

            if (_services.TryGetValue((type, srv.GetType().FullName), out var service)) return service;
            _services.Add((type, srv.GetType().FullName), srv);
            return srv;
        }
    }
}
