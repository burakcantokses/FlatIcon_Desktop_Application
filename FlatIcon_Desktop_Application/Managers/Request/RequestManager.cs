using FlatIcon_Desktop_Application.Schemas.Authentication;
using FlatIcon_Desktop_Application.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using Newtonsoft.Json.Linq;

namespace FlatIcon_Desktop_Application.Managers.Request
{
    public class RequestManager
    {
        public Type RequestType;
        public string ContentType { get; set; }
        public string Accept { get; set; }
        public RequestManager(Type type, string contentType = null, string accept = null)
        {
            RequestType = type;
            ContentType = contentType;
            Accept = accept;
        }

        /*public string getBearerToken(string url, string apiKey)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = RequestType.ToString();
            request.ContentType = ContentType;
            request.Accept = Accept;

            string postData = string.Format(
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                "Content-Disposition: form-data; name=\"apikey\"\r\n\r\n" +
                "{0}\r\n" +
                "------WebKitFormBoundary7MA4YWxkTrZu0gW--\r\n",
                apiKey);
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8))
                    {
                        string responseText = reader.ReadToEnd();
                        return responseText;
                    }
                }
            }
        }*/

        public object getBearerToken(string url, string apiKey)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = RequestType.ToString();
                request.ContentType = ContentType;
                request.Accept = Accept;

                string postData = string.Format(
                    "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\n" +
                    "Content-Disposition: form-data; name=\"apikey\"\r\n\r\n" +
                    "{0}\r\n" +
                    "------WebKitFormBoundary7MA4YWxkTrZu0gW--\r\n",
                    apiKey);
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);
                request.ContentLength = byteArray.Length;

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                string responseText = reader.ReadToEnd();
                                var jsonData = JObject.Parse(responseText)["data"];
                                LoginResponse loginResponse = new LoginResponse();
                                loginResponse.token = jsonData["token"].ToString();
                                loginResponse.expires = int.Parse(jsonData["expires"].ToString());
                                return loginResponse;
                            }
                            else if (response.StatusCode == HttpStatusCode.NotImplemented)
                            {
                                string errorResponseText = reader.ReadToEnd();
                                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorResponseText);
                                throw new Exception(errorResponse.error);
                            }
                            else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                            {
                                string errorResponseText = reader.ReadToEnd();
                                var errorResponse = JsonConvert.DeserializeObject<ApiKeyNotValid>(errorResponseText);
                                throw new Exception(errorResponse.error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

    }
}
