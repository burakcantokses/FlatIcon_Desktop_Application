using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Schemas.Authentication
{
    public class LoginResponse
    {
        public string token {  get; set; }
        public int expires { get; set; }
    }
}
