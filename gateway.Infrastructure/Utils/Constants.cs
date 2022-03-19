using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gateway.Infrastructure.Utils
{
    public class Constants
    {
        public const string JWT_SECRET = "YWUzNGdhc2VnZmEzZ2FzZ2FnMw==";
        public static int JWT_EXPIRATION_HOURS = 3;

        public static string USERS_MICROSERVICE_API = "API:users-microservice";
        public static string CONFIGURATION_MICROSERVICE_API = "API:configuration-microservice";
        public static string APPOINTMENTS_MICROSERVICE_API = "API:appointments-microservice";
        public static string MARKET_MICROSERVICE_API = "API:market-microservice";


    }
}
