using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Schemas.Authentication;
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
            object data = requestManager.getBearerToken(url, Program.API_KEY);
            if (data is LoginResponse)
            {
                LoginResponse loginResponse = (LoginResponse)data;
                return loginResponse.token;
            }
            else if (data is string)
            {
                string errorMessage = (string)data;
                return errorMessage;
            }
            return null;
        }
    }
}
