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

        public string request(string url, string apiKey, string body) 
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = RequestType.ToString();
            request.ContentType = ContentType;
            request.Accept = Accept;

            string postData = body;
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseText;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                responseText = reader.ReadToEnd();
                Console.WriteLine(responseText);
            }

            response.Close();
            return responseText;
        }
    }
}
