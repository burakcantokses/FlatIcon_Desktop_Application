using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Schemas.Icon;
using FlatIcon_Desktop_Application.Schemas.Pack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Managers.Search
{
    public class SearchPackManager
    {
        public string url { get; set; }
        // Required properties
        public string q { get; set; } // Term to search for

        // Optional properties
        public string orderBy { get; set; } // Order by in results ('priority' or 'added')
        public int? page { get; set; } // Page number
        public string styleColor { get; set; } // Filter results by color
        public string styleShape { get; set; } // Filter results by shape
        public int? limit { get; set; } // Number of max items returned per request
        public string iconType { get; set; } // Resource Type ('standard' or 'sticker')

        public PacksResponse packsResponse { get; set; }
        public SearchPackManager(string q)
        {
            url = Program.MAIN_URL + Program.VERSION + $"/search/packs/added?q={q}";
            packsResponse = searchPack(Program.authenticationManager.authenticationToken).Result;
        }

        public async Task<PacksResponse> searchPack(string authenticationToken)
        {
            RequestManager requestManager = new RequestManager(Request.Type.POST, null, "application/json");
            var response = await requestManager.GetSearchPacksAsync(url, authenticationToken);

            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
