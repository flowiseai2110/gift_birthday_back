using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Dto
{
    public class ParticipanteToken
    {
        public Guid participanteToken { get; set; }
        public int participanteId { get; set; }
        public int? participanteModId { get; set; }
        public string numDocumento { get; set; }
    }
}
