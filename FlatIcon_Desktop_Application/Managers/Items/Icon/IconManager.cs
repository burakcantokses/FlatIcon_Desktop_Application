using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Schemas.Icon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Managers.Items.Icon
{
    public class IconManager
    {
        public string url { get; set; }
        public int id { get; set; }
        public string iconType { get; set; }
        public IconResponse icon { get; set; }
        public IconManager(int id, string iconType = null)
        {
            url = Program.MAIN_URL + Program.VERSION + "/item/icon/"+id;
            this.id = id;
            this.iconType = iconType;
            icon = getIcon(url, Program.authenticationManager.authenticationToken).Result;
        }

        public async Task<IconResponse> getIcon(string  url, string authenticationToken)
        {
            RequestManager requestManager = new RequestManager(Request.Type.GET, null, "application/json");
            var response = await requestManager.GetIconAsync(url, authenticationToken);

            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
