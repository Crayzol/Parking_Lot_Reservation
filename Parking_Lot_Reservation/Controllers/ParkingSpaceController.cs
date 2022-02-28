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
        public async Task<ActionResult<ParkingSpaceModel>> Add([FromBody] ParkingSpaceDTO parkingSpaceDTO)
        {

            var parkingSpaceAdd = new ParkingSpaceModel
            {
                IsReserved = parkingSpaceDTO.IsReserved,
                HasCharger = parkingSpaceDTO.HasCharger,
            };

            if (ModelState.IsValid)
            {
                _ = await _dbContext.ParkingSpaces.AddAsync(parkingSpaceAdd);
                _ = await _dbContext.SaveChangesAsync();
            }

            return parkingSpaceAdd;
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
            if (id < 0)
            {
                return new BadRequestObjectResult("Id is incorrect");
            }

            var parkingSpace = await _dbContext.ParkingSpaces.FirstOrDefaultAsync(parking => parking.ParkingId.Equals(id));

            if (parkingSpace is null)
            {
                return new BadRequestObjectResult("Parking space is null");
            }

            _ =_dbContext.ParkingSpaces.Remove(parkingSpace);
            _ = await _dbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
