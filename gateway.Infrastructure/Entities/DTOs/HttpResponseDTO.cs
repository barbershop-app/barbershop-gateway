using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace gateway.Infrastructure.Entities.DTOs
{
    public class HttpResponseDTO
    {
        public HttpStatusCode StatusCode { get; set; }
        public object? Data { get; set; }
    }
}
