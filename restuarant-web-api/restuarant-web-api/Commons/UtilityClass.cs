using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace restaurant_web_api.Commons
{
    public class UtilityClass
    {
        public async Task<string> CallGETMethod(string url)
        {
            try
            {
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/json";
                WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
                var responseStream = responseObject.GetResponseStream();
                var sr = new StreamReader(responseStream);
                string received = await sr.ReadToEndAsync();
                return received;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
