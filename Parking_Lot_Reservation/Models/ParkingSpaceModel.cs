using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_Reservation.Models
{
    public class ParkingSpaceModel
    {
        [Key]
        public int ParkingSpaceId { get; set; }
        public bool IsReserved { get; set; }
        public bool IsCharger { get; set; }
    }
}
