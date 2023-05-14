using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Schemas.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Managers.Tags
{
    public class TagsManager
    {
        public int? page { get; set; }
        public int? limit { get; set; }
        public int? havingStickers { get; set; }
        public string url { get; set; }

        public TagsResponse tags { get; set; }

        public TagsManager(int? page = null, int? limit = null, int? havingStickers = null)
        {
            url = Program.MAIN_URL + Program.VERSION + "/tags";
            this.page = page;
            this.limit = limit;
            this.havingStickers = havingStickers;
            tags = getTags(url, Program.authenticationManager.authenticationToken).Result;
        }

        public async Task<TagsResponse> getTags(string url, string authenticationToken)
        {
            RequestManager requestManager = new RequestManager(Request.Type.POST, null, "application/json");
            var response = await requestManager.getTags(url, authenticationToken);

            if (response != null)
            {
                return response;
            }
            return null;
        }
    }
}
