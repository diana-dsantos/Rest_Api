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
    public class BuildingsController : ControllerBase
    {
        private readonly RestAPIContext _context;

        public BuildingsController(RestAPIContext context)
        {
            _context = context;
        }        

//----------------------------------- Retrieving all information from a specific Building -----------------------------------\\

        // GET: api/Buildings/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuilding(long id)
        {
            var building = await _context.buildings.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }

            return building;
        }

//--------- Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention ---------\\

        // GET: api/Buildings/InterventionList
        [HttpGet("InterventionList")]
        public ActionResult<List<Building>> GetToFixBuildings()
        {
            IQueryable<Building> InterventionList = from BuildingsList in _context.buildings
            join batteries in _context.batteries on BuildingsList.id equals batteries.building_id
            join columns in _context.columns on batteries.id equals columns.battery_id
            join elevators in _context.elevators on columns.id equals elevators.column_id
            where (batteries.status == "Intervention") || (columns.status == "Intervention") || (elevators.status == "Intervention")
            select BuildingsList;

            return InterventionList.Distinct().ToList();
        }


        private bool BuildingExists(long id)
        {
            return _context.buildings.Any(e => e.id == id);
        }
    }
}
