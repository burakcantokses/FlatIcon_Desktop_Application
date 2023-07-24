using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Schemas.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Managers.Styles
{
    public class StyleManager
    {
        public string url { get; set; }

        // Required properties
        public int id {  get; set; }
        
        // Schema
        public StyleResponse style { get; set; }
        public StyleManager(int id)
        {
            url = Program.MAIN_URL + Program.VERSION + "/style/"+id;
            this.id = id;
            style = getStyle(url, Program.authenticationManager.authenticationToken).Result;
        }

        public async Task<StyleResponse> getStyle(string url, string authenticationToken)
        {
            RequestManager requestManager = new RequestManager(Request.Type.GET, null, "application/json");
            var response = await requestManager.GetStyleAsync(url, authenticationToken);

            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
