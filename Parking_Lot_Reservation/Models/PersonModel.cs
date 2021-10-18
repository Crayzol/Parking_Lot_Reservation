using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_Reservation.Models
{
    public class PersonModel
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ParkingSpaceID { get; set; }
    }
}
