using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Dto.Services.Secciones
{
    public class ValidacionResponse
    {
        public IList<RequisitoResponse> requisitos { get; set; }
        public ValidacionResponse()
        {
            requisitos = new List<RequisitoResponse>();
        }
    }
    public class RequisitoResponse
    {
        public string codigo { get; set; }
        public int seccionId { get; set; }
        public bool success { get; set; }
        public IList<string> messages { get; set; }
        public RequisitoResponse()
        {
            messages = new List<string>();
        }
    }
}
