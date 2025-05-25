using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Interface;
using Web.Data.ICore;

namespace Web.Api.UseCases.Services
{
    public class BaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IContext _context;
     
        public BaseService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._context = unitOfWork.Context;
        }
    }
}
