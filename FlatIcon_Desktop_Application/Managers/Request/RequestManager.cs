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
using FlatIcon_Desktop_Application.Schemas.Tag;
using FlatIcon_Desktop_Application.Schemas.Icon;
using FlatIcon_Desktop_Application.Schemas.Pack;
using System.Security.Policy;

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

        #region GetBearerTokenAsync
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
        #endregion

        #region GetStylesAsync
        public async Task<StylesResponse> GetStylesAsync(string url, string authenticationToken)
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
        #endregion

        #region GetStyleAsync
        public async Task<StyleResponse> GetStyleAsync(string url, string authenticationToken)
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
                    var styleResponse = JsonConvert.DeserializeObject<StyleResponse>(responseText);
                    return styleResponse;
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
        #endregion

        #region GetTagsAsync
        public async Task<TagsResponse> GetTagsAsync(string url, string authenticationToken)
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
                    var tagsResponse = JsonConvert.DeserializeObject<TagsResponse>(responseText);
                    return tagsResponse;
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
        #endregion

        #region GetIconAsync
        public async Task<IconResponse> GetIconAsync(string url, string authenticationToken)
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
                    var iconResponse = JsonConvert.DeserializeObject<IconResponse>(responseText);
                    return iconResponse;
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
        #endregion

        #region GetPackResponseAsync
        public async Task<PackResponse> GetPackResponseAsync(string url, string authenticationToken)
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
                    var packResponse = JsonConvert.DeserializeObject<PackResponse>(responseText);
                    return packResponse;
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
        #endregion

        #region DownloadIconAsync
        public async Task DownloadIconAsync(string url, string authenticationToken, string fileName)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", authenticationToken));
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(Accept));
            try
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    byte[] imageData = await response.Content.ReadAsByteArrayAsync();
                    File.WriteAllBytes(fileName, imageData);
                    Console.WriteLine($"Image downloaded and saved as {fileName}");
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
        #endregion

    }
}
