using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gateway.Infrastructure.Entities.DTOs
{
    public class BarberShopWorkDaysDTOs
    {
        public class Update
        {
            public int BarberShopId { get; set; }
            public DayOfWeek Day { get; set; }
            public DateTime StartHour { get; set; }
            public bool IsOpen { get; set; }
            public int BookingLimit { get; set; }

        }
    }
}
