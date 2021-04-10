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
    public class InterventionsController : ControllerBase
    {
        private readonly RestAPIContext _context;

        public InterventionsController(RestAPIContext context)
        {
            _context = context;
        }

//----------------------------------- Retrieving all information from a specific Battery -----------------------------------\\

        // GET: api/Interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> Getinterventions()
        {
            return await _context.interventions.ToListAsync();
        }


//---------- Returns all fields of all intervention Request records that do not have a start date and are in "Pending" status. -----------\\

        // GET: api/Interventions/Pending
        [HttpGet("Pending")]
        public object GetInterventions()
        {
            return _context.interventions
                        .Where(intervention => intervention.status == "Pending" 
                            && intervention.start_date_time_intervention == null);            
        }


//----------- Change the status of the intervention request to "InProgress" and add a start date and time (Timestamp) -------------\\

        // PUT: api/Interventions/id/InProgress
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/InProgress")]
        public async Task<IActionResult> PutIntervention(long id, Intervention intervention)
        {
            if (id != intervention.id)
            {
                return BadRequest();
            }

            Intervention interventionFound = await _context.interventions.FindAsync(id);
            interventionFound.status = intervention.status;            
            interventionFound.start_date_time_intervention = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


//----------- Change the status of the request for action to "Completed" and add an end date and time (Timestamp) -------------\\

        // PUT: api/Interventions/id/Completed
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/Completed")]
        public async Task<IActionResult> PutIntervention2(long id, Intervention intervention)
        {
            if (id != intervention.id)
            {
                return BadRequest();
            }

            Intervention interventionFound = await _context.interventions.FindAsync(id);
            interventionFound.status = intervention.status;            
            interventionFound.end_date_time_intervention = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

//----------------------------------------------- Create a new intervention ------------------------------------------------\\

        // POST: api/Interventions
        [HttpPost]
        public async Task<ActionResult<Intervention>> PostIntervention(Intervention newIntervention)
        {
            newIntervention.created_at= DateTime.Now;
            newIntervention.status = "InProgress";
            newIntervention.result = "Incomplete";
            newIntervention.employee_id = null;

            _context.interventions.Add(newIntervention);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool InterventionExists(long id)
        {
            return _context.interventions.Any(e => e.id == id);
        }
    }
}
