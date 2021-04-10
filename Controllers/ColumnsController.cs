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
    public class ColumnsController : ControllerBase
    {
        private readonly RestAPIContext _context;

        public ColumnsController(RestAPIContext context)
        {
            _context = context;
        }



//----------------------------------- Retrieving all information from a specific Column -----------------------------------\\
        
        //GET: api/Columns/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Column>> GetColumn(long id)
        {
            var column = await _context.columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column;
        }

//----------------------------------- Retrieving the current status of a specific Column -----------------------------------\\
        
        // GET: api/Columns/id/Status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<string>> GetColumnStatus([FromRoute] long id)
        {
            var column = await _context.columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column.status;
        }


//----------------------------------- Changing the status of a specific Column -----------------------------------\\
        
        // PUT: api/Columns/id/Status        
        [HttpPut("{id}/Status")]
        public async Task<ActionResult<string>> PutColumn([FromRoute] long id, Column column)
        {
            if (id != column.id)
            {
                return BadRequest();
            }
            
            if (column.status == "Active" || column.status == "Inactive" || column.status == "Intervention")
            {
                Column columnFound = await _context.columns.FindAsync(id);
                columnFound.status = column.status;

                try
                {
                    await _context.SaveChangesAsync();
                    return column.status;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColumnExists(id))
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


        private bool ColumnExists(long id)
        {
            return _context.columns.Any(e => e.id == id);
        }
    }
}
