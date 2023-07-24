using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Schemas.Style;
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

        // Optional properties
        public int? page { get; set; }
        public int? limit { get; set; }

        // Schema
        public StylesResponse styles { get; set; }

        public StylesManager(int? page = null, int? limit = null)
        {
            this.page = page;
            this.limit = limit;
            url = Program.MAIN_URL + Program.VERSION + "/styles";
            styles = getStyles(url, Program.authenticationManager.authenticationToken).Result;
        }

        public async Task<StylesResponse> getStyles(string url, string authenticationToken)
        {
            RequestManager requestManager = new RequestManager(Request.Type.GET, null, "application/json");
            var response = await requestManager.GetStylesAsync(url, authenticationToken);

            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
