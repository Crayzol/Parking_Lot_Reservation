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
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("addPerson")]
        public async Task<ActionResult<PersonDTO>> Add([FromBody] PersonDTO personDTO)
        {
            if (string.IsNullOrEmpty(personDTO.Name) || string.IsNullOrEmpty(personDTO.Surname))
            {
                return new BadRequestObjectResult("Id is or surname is null or empty");
            }

            var personAdd = new PersonModel
            {
                Name = personDTO.Name,
                Surname = personDTO.Surname
            };

            _ = await _dbContext.People.AddAsync(personAdd);
            _ = await _dbContext.SaveChangesAsync();

            return personDTO;
        }

        [HttpGet("getPeople")]
        public async Task<ActionResult<IEnumerable<PersonModel>>> GetAllPeople()
        {
            var people = await _dbContext.People.ToListAsync();

            if (!people.Any())
            {
                return new EmptyResult();
            }

            return people;
        }



        [HttpDelete("removePerson")]
        public async Task<ActionResult<PersonDTO>> Remove(int id)
        {
            var person = await _dbContext.People.FindAsync(id);

            if (person is null)
            {
                return new BadRequestObjectResult("Id is incorrect");
            }

            _ = _dbContext.People.Remove(person);
            _ = await _dbContext.SaveChangesAsync();

            return new PersonDTO { Name = person.Name, Surname = person.Surname };
        }

        [HttpGet("ShowEverything")]
        public async Task<ActionResult<IEnumerable<PersonModel>>> GetAllInfo()
        {
            var peopleList = await _dbContext.People.Include(model => model.AssignesParkingSpaces).ToListAsync();

            return peopleList;
        }
    }
}
