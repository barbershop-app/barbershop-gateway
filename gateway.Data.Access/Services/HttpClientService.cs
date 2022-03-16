using gateway.Core.IServices;
using gateway.Infrastructure.Entities.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
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

        public async Task<HttpResponseDTO> Get(string service, string controller, string action)
        {
            var httpClient = _httpClientFactory.CreateClient("localhost");

            using (var response = await httpClient.GetAsync($"{_configuration.GetValue<string>(service)}/{controller}/{action}"))
            {
                var content = await response.Content.ReadAsStringAsync();

                ExpandoObject? res = JsonConvert.DeserializeObject<ExpandoObject>(content);

                return new HttpResponseDTO { StatusCode = response.StatusCode, Data = res };
            }
        }

        public async Task<HttpResponseDTO> Get(string service, string controller, string action, string urlParameter)
        {
            var httpClient = _httpClientFactory.CreateClient("localhost");

            using (var response = await httpClient.GetAsync($"{_configuration.GetValue<string>(service)}/{controller}/{action}/{urlParameter}"))
            {
               var content = await response.Content.ReadAsStringAsync();

               ExpandoObject? res = JsonConvert.DeserializeObject<ExpandoObject>(content);

               return new HttpResponseDTO { StatusCode = response.StatusCode ,Data = res };
            }
        }


        public async Task<HttpResponseDTO> Post(string service, string controller, string action , object values)
        {
            var httpClient = _httpClientFactory.CreateClient("localhost");

            var json = JsonConvert.SerializeObject(values);

            var context = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync($"{_configuration.GetValue<string>(service)}/{controller}/{action}", context))
            {
                var content = await response.Content.ReadAsStringAsync();

                ExpandoObject? res = JsonConvert.DeserializeObject<ExpandoObject>(content);

                return new HttpResponseDTO { StatusCode = response.StatusCode, Data = res };
            }
        }
    }
}
