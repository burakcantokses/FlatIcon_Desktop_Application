using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Schemas.Icon
{
    public class IconsResponse
    {
        public List<Icons> data { get; set; }
        public Metadata metadata { get; set; }
    }
}
