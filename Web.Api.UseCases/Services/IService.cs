using Release.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.UseCases.Services
{
    public interface IService<T>
    {
        StatusResponse<T> GetData(bool cache = false, object filter = null);
       
    }
}
