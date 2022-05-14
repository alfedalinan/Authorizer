using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizer.Business.Entities
{
    public class Payload
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Exp { get; set; }
    }
}
