using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_Reservation.Models
{
    public class ParkingSpaceModel
    {
        public int ParkingSpaceID { get; set; }
        public bool IsReserved { get; set; }
    }
}
