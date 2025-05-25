using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.UseCases.Common.Bases;

namespace Web.Api.UseCases.Common.Exceptions
{
    public class ValidationExceptionCustom : Exception
    {
        public ValidationExceptionCustom() : base("Uno o mas validaciones fallaron")
        { 
            Errors = new List<BaseError>();
        }
        public ValidationExceptionCustom( IEnumerable<BaseError> errors ) : this()
        {
            Errors = errors;
        }
        public IEnumerable<BaseError> Errors { get; }
    }
}
