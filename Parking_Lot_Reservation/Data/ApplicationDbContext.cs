using Microsoft.EntityFrameworkCore;
using Parking_Lot_Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_Reservation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<PersonModel> People { get; set; }
        public DbSet<ParkingSpaceModel> ParkingSpaces { get; set; }
    }
}
