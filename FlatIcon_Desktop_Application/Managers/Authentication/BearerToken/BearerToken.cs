using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Managers.Authentication.BearerToken
{
    public class BearerToken
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string token { get; set; }
        public int expires { get; set; }
    }
}
