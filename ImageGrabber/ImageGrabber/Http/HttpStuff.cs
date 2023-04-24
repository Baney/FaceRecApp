using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Dynamic;
using System.Net.Http.Headers;

namespace ImageGrabber.Http
{
    internal class HttpStuff
    {
        readonly string _endPoint;
        readonly string _ipAddress;
        public HttpStuff(string Endpoint, String IpAddr)
        {
            _endPoint = Endpoint;
            _ipAddress = IpAddr;
        }

        public async Task<string> Grabit()
        {
            try
            {
                using var httpClient = new HttpClient();

                var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("admin:1234abcd"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                
                var response = await httpClient.GetAsync(BuildEndpointRequest());
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception ex)
            {
                return ex.ToString();
                throw;
            }

        }

        private string BuildEndpointRequest()
        {
            
            var endpointRequest = "ISAPI/System/status";
            var requestUrl = ($"http://{_ipAddress}/{endpointRequest}");

            return requestUrl;
        }
    }

    public enum EndPointUrls
    {
        GetModel,
        TrigerRelay,
        GrabImage,         
    }  
}
