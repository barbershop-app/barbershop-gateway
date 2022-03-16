using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gateway.Core.IServices
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> Get(string service, string controller, string action);
        Task<HttpResponseMessage> Post(string service, string controller, string action, object values);
    }
}
