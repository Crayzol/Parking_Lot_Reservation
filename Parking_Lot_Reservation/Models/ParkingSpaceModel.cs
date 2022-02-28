using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Parking_Lot_Reservation.Models
{
    public class ParkingSpaceModel
    {
        [Key]
        public int ParkingId { get; set; }
        public int PersonId { get; set; }
        public bool IsReserved { get; set; }
        public bool HasCharger { get; set; }
        
        [JsonIgnore]
        [ForeignKey("PersonId")]
        public virtual PersonModel PersonModel { get; set; }
    }
}
