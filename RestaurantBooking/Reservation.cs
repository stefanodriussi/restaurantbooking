using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking
{
    public record Reservation(string Id, string ClientName, string ClientNumber, IEnumerable<Table> Tables);
}
