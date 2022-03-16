using gateway.Core;
using gateway.Data.SQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gateway.Data.SQL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APIGatewayContext _context;
        public UnitOfWork(APIGatewayContext context)
        {
            this._context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
