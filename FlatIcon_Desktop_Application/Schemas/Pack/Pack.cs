using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Schemas.Pack
{
    public class Pack
    {
        public int id { get; set; }
        public string description { get; set; }
        public string colors { get; set; }
        public string color { get; set; }
        public string shape { get; set; }
        public int family_id { get; set; }
        public string family_name { get; set; }
        public string team_name { get; set; }
        public int added { get; set; }
        public int pack_items { get; set; }
        public string tags { get; set; }
        public int equivalents { get; set; }
        public Dictionary<string,string> images { get; set; }
    }
}
