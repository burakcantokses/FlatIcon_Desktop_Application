using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Schemas.Style
{
    public class Style
    {
        public string id { get; set; }
        public string icons { get; set; }
        public string packs { get; set; }
        public string color { get; set; }
        public string shape { get; set; }
        public int? family_id { get; set; }
        public int? family_icons { get; set; }
        public string family_name { get; set; }
    }
}
