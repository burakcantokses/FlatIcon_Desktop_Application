using FlatIcon_Desktop_Application.Managers.Authentication.BearerToken;
using FlatIcon_Desktop_Application.Managers.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application.Managers.Authentication
{
    public class AuthenticationManager
    {
        public string authenticationToken { get; set; }
        public string url { get; set; }

        public AuthenticationManager(string apiKey) 
        {
            url = Program.MAIN_URL + Program.VERSION + "/app/authentication";
            authenticationToken = GetBearerToken();
        }

        public string GetBearerToken()
        {
            RequestManager requestManager = new RequestManager(Request.Type.POST, "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW", "application/json");
            string data = requestManager.getBearerToken(url, Program.API_KEY);
            BearerToken.BearerToken bearerToken = JsonConvert.DeserializeObject<BearerToken.BearerToken>(data);
            return bearerToken.data.token;
        }
    }
}
