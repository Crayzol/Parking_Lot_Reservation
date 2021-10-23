using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_Reservation.Models
{
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [ForeignKey("ParkingSpaceModel")]
        public ParkingSpaceModel ParkingSpaceId { get; set; }
    }
}
