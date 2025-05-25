using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.Entidades
{
    public class BaseRequest
    {
        public string userName { get; set; }
        public string userIpAddress { get; set; }
        public string appHost { get; set; }
    }
}
