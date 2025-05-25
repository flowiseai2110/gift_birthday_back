using DataAccess.DA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.BL
{
    public class PersonaBL
    {
        public Task<List<Persona>> getListPersona() { 
            return new SupabaseService().getListPersona();
        }
    }
}
