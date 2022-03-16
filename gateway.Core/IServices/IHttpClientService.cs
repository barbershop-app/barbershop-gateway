using gateway.Infrastructure.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gateway.Core.IServices
{
    public interface IHttpClientService
    {
        Task<HttpResponseDTO> Get(string service, string controller, string action);
        Task<HttpResponseDTO> Get(string service, string controller, string action, string urlParameter);
        Task<HttpResponseDTO> Post(string service, string controller, string action, object values);
    }
}
