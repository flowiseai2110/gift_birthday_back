using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Web.Api.Helper.Excepciones
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, object errores = null)
        {
            Code = code;
            Errores = errores;
        }

        public HttpStatusCode Code { get; }
        public object Errores { get; }
    }
}
