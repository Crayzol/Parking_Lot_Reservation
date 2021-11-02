using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Lot_Reservation.Data;
using Parking_Lot_Reservation.DTOs;
using Parking_Lot_Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot_Reservation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingSpaceController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ParkingSpaceController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("addParkingSpace")]
        public async Task<ActionResult<ParkingSpaceDTO>> Add([FromBody] ParkingSpaceDTO ParkingSpaceDTO)
        {

            var parkingSpaceAdd = new ParkingSpaceModel
            {
                IsReserved = ParkingSpaceDTO.IsReserved,
                HasCharger = ParkingSpaceDTO.HasCharger
            };
            await _dbContext.ParkingSpaces.AddAsync(parkingSpaceAdd);
            await _dbContext.SaveChangesAsync();

            return ParkingSpaceDTO;
        }

        [HttpGet("getParkingSpaces")]
        public async Task<ActionResult<IEnumerable<ParkingSpaceModel>>> GetAllParkingSpaces()
        {
            var parkingSpaces = await _dbContext.ParkingSpaces.ToListAsync();

            if (!parkingSpaces.Any())
            {
                return new EmptyResult();
            }

            return parkingSpaces;
        }



        [HttpDelete("removeParkingSpace")]
        public async Task<ActionResult<ParkingSpaceDTO>> Remove(int id)
        {
            var parkingSpace = await _dbContext.ParkingSpaces.FindAsync(id);

            if (parkingSpace is null)
            {
                return new BadRequestResult();
            }

            _ = _dbContext.ParkingSpaces.Remove(parkingSpace);
            _ = await _dbContext.SaveChangesAsync();

            return new ParkingSpaceDTO { HasCharger = parkingSpace.HasCharger, IsReserved = parkingSpace.IsReserved };
        }
    }
}
