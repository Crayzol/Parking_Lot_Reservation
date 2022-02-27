using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parking_Lot_Reservation.Models;

namespace Parking_Lot_Reservation.DTOs
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<ParkingSpaceModel> ParkingSpaceModels { get; set; }
    }
}
