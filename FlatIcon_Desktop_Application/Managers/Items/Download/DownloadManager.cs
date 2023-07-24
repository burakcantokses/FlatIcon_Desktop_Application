using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Schemas.Icon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Managers.Items.Download
{
    public class DownloadManager
    {
        public string url {  get; set; }
        public int id { get; set; }
        public string format { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string iconType { get; set; }

        public DownloadManager(int id, string format, string color = null, string size = null, string iconType = null)
        {
            url = Program.MAIN_URL + Program.VERSION + "/item/icon/download/" + id;
            this.id = id;
            this.format = format;
            this.color = color;
            this.size = size;
            this.iconType = iconType;
        }

        public async Task downloadIcon(string authenticationToken, string fileName)
        {
            RequestManager requestManager = new RequestManager(Request.Type.GET, null, "application/json");
            await requestManager.DownloadIconAsync(url, authenticationToken, fileName);
        }
    }
}
