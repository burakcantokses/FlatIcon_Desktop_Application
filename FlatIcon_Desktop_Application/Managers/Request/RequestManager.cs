using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        public string getBearerToken(string url, string apiKey)
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
        }
    }
}
