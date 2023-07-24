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
        public string q { get; set; }

        // Optional properties
        public string orderBy { get; set; }
        public int? page { get; set; }
        public string styleColor { get; set; }
        public string styleShape { get; set; }
        public int? limit { get; set; }
        public string iconType { get; set; }

        public PacksResponse packsResponse { get; set; }
        public SearchPackManager(string q)
        {
            url = Program.MAIN_URL + Program.VERSION + $"/search/packs/added?q={q}";
            packsResponse = searchPack(Program.authenticationManager.authenticationToken).Result;
        }

        public async Task<PacksResponse> searchPack(string authenticationToken)
        {
            RequestManager requestManager = new RequestManager(Request.Type.GET, null, "application/json");
            var response = await requestManager.GetSearchPacksAsync(url, authenticationToken);

            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
