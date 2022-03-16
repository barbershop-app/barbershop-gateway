using gateway.Core.IServices;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gateway.Data.Access.Services
{
    public class HttpClientService : IHttpClientService
    {

        IHttpClientFactory _httpClientFactory;
        IConfiguration _configuration; 

        public HttpClientService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> Get(string service, string controller, string action)
        {
            var httpClient = _httpClientFactory.CreateClient("localhost");

            using (var response = await httpClient.GetAsync(_configuration.GetValue<string>($"{service}/{controller}/{action}")))
            {
                return response;
            }
        }

        public async Task<HttpResponseMessage> Get(string service, string controller, string action, string urlParameter)
        {
            var httpClient = _httpClientFactory.CreateClient("localhost");

            using (var response = await httpClient.GetAsync(_configuration.GetValue<string>($"{service}/{controller}/{action}/{urlParameter}")))
            {
                return response;
            }
        }


        public async Task<HttpResponseMessage> Post(string service, string controller, string action , object values)
        {
            var httpClient = _httpClientFactory.CreateClient("localhost");

            var json = JsonConvert.SerializeObject(values);

            var context = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync(_configuration.GetValue<string>($"{service}/{controller}/{action}"), context))
            {
                return response;
            }
        }
    }
}
