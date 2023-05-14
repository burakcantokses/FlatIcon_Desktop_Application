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
using System.Net.Http;
using FlatIcon_Desktop_Application.Schemas.Style;

namespace FlatIcon_Desktop_Application.Managers.Request
{
    public class RequestManager
    {
        public Type RequestType;
        public string ContentType { get; set; }
        public string Accept { get; set; }
        public HttpClient httpClient { get; set; }
        public RequestManager(Type type, string contentType = null, string accept = null)
        {
            RequestType = type;
            ContentType = contentType;
            Accept = accept;
            httpClient = new HttpClient();
        }


        /*public object getBearerToken(string url, string apiKey)
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
        }*/

        public async Task<LoginResponse> GetBearerTokenAsync(string url, string apiKey)
        {
            var requestContent = new MultipartFormDataContent("------WebKitFormBoundary7MA4YWxkTrZu0gW");
            requestContent.Add(new StringContent(apiKey), "apikey");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url) { Content = requestContent };

            try
            {
                var response = await httpClient.SendAsync(requestMessage);
                if (response.IsSuccessStatusCode)
                {
                    var responseText = await response.Content.ReadAsStringAsync();
                    var jsonData = JObject.Parse(responseText)["data"];
                    var loginResponse = new LoginResponse
                    {
                        token = jsonData["token"].ToString(),
                        expires = int.Parse(jsonData["expires"].ToString())
                    };
                    return loginResponse;
                }
                else if (response.StatusCode == HttpStatusCode.NotImplemented)
                {
                    var errorResponseText = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(errorResponseText);
                    throw new Exception(errorResponse.error);
                }
                else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    var errorResponseText = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<ApiKeyNotValid>(errorResponseText);
                    throw new Exception(errorResponse.error);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<StylesResponse> getStyles(string url, string authenticationToken)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", authenticationToken));
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(Accept));
            try
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseText = await response.Content.ReadAsStringAsync();
                    var stylesResponse = JsonConvert.DeserializeObject<StylesResponse>(responseText);
                    return stylesResponse;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var errorResponseText = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<ExpiredToken>(errorResponseText);
                    throw new Exception(errorResponse.status + " " + errorResponse.message);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
