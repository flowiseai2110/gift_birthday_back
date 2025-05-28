using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities
{
    public class EventoGift
    {
        public int id { get; set; }
        public int evento_id { get; set; }
        public int gift_id { get; set; }
        public int cantidad { get; set; }
    }
}
