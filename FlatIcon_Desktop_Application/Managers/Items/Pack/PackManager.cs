using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Schemas.Pack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Managers.Items.Pack
{
    public class PackManager
    {
        public string url { get; set; }
        public int id { get; set; }
        public string iconType { get; set; }
        public PackResponse pack { get; set; }

        public PackManager(int id, string iconType = null)
        {
            url = Program.MAIN_URL + Program.VERSION + "/item/pack/" + id;
            this.id = id;
            this.iconType = iconType;
            pack = getPack(url, Program.authenticationManager.authenticationToken).Result;
        }

        public async Task<PackResponse> getPack(string url, string authenticationToken)
        {
            RequestManager requestManager = new RequestManager(Request.Type.POST, null, "application/json");
            var response = await requestManager.GetPackResponseAsync(url, authenticationToken);

            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
