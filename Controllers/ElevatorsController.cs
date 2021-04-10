using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorsController : ControllerBase
    {
        private readonly RestAPIContext _context;

        public ElevatorsController(RestAPIContext context)
        {
            _context = context;
        }

//------------------- Retrieving a list of Elevators that are not in operation at the time of the request -------------------\\

        // GET: api/Elevators/NotActive
        [HttpGet("NotActive")]
        public object GetElevators()
        {
            return _context.elevators
                        .Where(elevator => elevator.status != "Active")
                        .Select(elevator => new {elevator.id, elevator.serial_number, elevator.status});
            
        }

//----------------------------------- Retrieving all information from a specific Elevator -----------------------------------\\

        //GET: api/Elevators/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> GetElevator(long id)
        {
            var elevator = await _context.elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator;
        }

//----------------------------------- Retrieving the current status of a specific Elevator -----------------------------------\\

        // GET: api/Elevators/id/Status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<string>> GetColumnStatus([FromRoute] long id)
        {
            var elevator = await _context.elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator.status;
        }

//----------------------------------- Changing the status of a specific Elevator -----------------------------------\\

        // PUT: api/Elevators/id/Status        
        [HttpPut("{id}/Status")]
        public async Task<ActionResult<string>> PutElevator([FromRoute] long id, Elevator elevator)
        {
            if (id != elevator.id)
            {
                return BadRequest();
            }
            
            if (elevator.status == "Active" || elevator.status == "Inactive" || elevator.status == "Intervention")
            {
                Elevator elevatorFound = await _context.elevators.FindAsync(id);
                elevatorFound.status = elevator.status;

                try
                {
                    await _context.SaveChangesAsync();
                    return elevator.status;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElevatorExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Content("Valid status: Intervention, Inactive, Active. Try again!  ");
        }        

        
        private bool ElevatorExists(long id)
        {
            return _context.elevators.Any(e => e.id == id);
        }
    }
}
