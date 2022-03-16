using gateway.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gateway.Core
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
