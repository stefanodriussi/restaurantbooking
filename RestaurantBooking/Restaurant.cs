using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking
{
    public class Restaurant
    {
        public Restaurant(string name, string ownerName, IEnumerable<Table> tables)
        {
            Name = name;
            OwnerName = ownerName;
            this.tables.AddRange(tables.OrderBy(table => table.Seats));
        }
        private List<Table> tables = new List<Table>();

        public string Name { get; }
        public string OwnerName { get; }

        public int AvailableTables => tables.Count;
        public int AvailableSeats => tables.Sum(t => t.Seats);

        public Reservation BookTable(string clientName, string phoneNumber, int requestedSeats)
        {
            if (requestedSeats > AvailableSeats) throw new NotEnoughTablesException();

            var allocatedSeats = 0;
            var bookedTables = new List<Table>();
            while (requestedSeats > allocatedSeats)
            {
                var table = tables.First();
                allocatedSeats += table.Seats;
                tables.RemoveAt(0);
                bookedTables.Add(table);
            }

            return new Reservation(Guid.NewGuid().ToString(), clientName, phoneNumber, bookedTables);
        }
    }
}
