using FlatIcon_Desktop_Application.Managers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Managers.Styles
{
    public class StylesManager
    {
        public string url { get; set; }

        public StylesManager() {
            url = Program.MAIN_URL + Program.VERSION + "/styles";
            Console.WriteLine(getStyles(url, Program.authenticationManager.authenticationToken).Result);
        }

        public async Task<string> getStyles(string url, string authenticationToken)
        {
            RequestManager requestManager = new RequestManager(Request.Type.POST, null, "application/json");
            var response = await requestManager.getStyles(url, authenticationToken);

            if (response != null)
            {
                return response.data[0].packs;
            }
            return null;
        }
    }
}
