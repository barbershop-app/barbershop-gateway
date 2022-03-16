using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gateway.Data.SQL
{
    public class APIGatewayContext : DbContext
    {
        public APIGatewayContext(DbContextOptions options) : base(options)
        {
        }

    }
}
