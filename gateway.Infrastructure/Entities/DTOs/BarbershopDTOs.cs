using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gateway.Infrastructure.Entities.DTOs
{
    public class BarberShopDTOs
    {
        public class Create
        {
            public Guid OwnerId { get; set; }
            public string Address { get; set; }
        }

        public class Update
        {
            public int Id { get; set; }
            public Guid OwnerId { get; set; }
            public string Address { get; set; }
        }


        public class GetBookingLimit
        {
            public int BarberShopId { get; set; }
            public DayOfWeek Day { get; set; }
        }
    }
}
