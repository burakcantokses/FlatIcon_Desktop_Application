using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Schemas.Icon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Managers.Search
{
    public class SearchIconManager
    {
        // Headers
        public string Authorization { get; set; }
        public string url { get; set; }
        // URI Parameters
        public string orderBy { get; set; }

        // Query Parameters
        public int? page { get; set; }
        public string q { get; set; }
        public int? packId { get; set; }
        public string styleColor { get; set; }
        public string styleShape { get; set; }
        public int? limit { get; set; }
        public string iconType { get; set; }

        public IconsResponse iconResponse { get; set; }

        public SearchIconManager(string q)
        {
            url = Program.MAIN_URL + Program.VERSION + $"/search/icons/added?q={q}";
            this.orderBy = orderBy;
            this.page = page;
            this.q = q;
            this.packId = packId;
            this.styleColor = styleColor;
            this.styleShape = styleShape;
            this.limit = limit;
            this.iconType = iconType;
            iconResponse = searchIcon(Program.authenticationManager.authenticationToken).Result;
        }

        public async Task<IconsResponse> searchIcon(string authenticationToken)
        {
            RequestManager requestManager = new RequestManager(Request.Type.POST, null, "application/json");
            var response = await requestManager.GetSearchIconsAsync(url, authenticationToken);
            
            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
