using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities.config
{ 
    public class Empresa : EntityBase
    {
        //public Empresa() {
        //    localesComerciales = new HashSet<LocalComercial>();
        //}    
        public int empresa_id { get; set; } = 0;
        public string razon_social { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public string telefono_principal { get; set; }
        public string celular_principal { get; set; }

        //public virtual ICollection<LocalComercial> localesComerciales { get; set; }
    }
 
}
