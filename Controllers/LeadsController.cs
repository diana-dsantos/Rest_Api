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
    public class LeadsController : ControllerBase
    {
        private readonly RestAPIContext _context;

        public LeadsController(RestAPIContext context)
        {
            _context = context;
        }

        // GET: api/Leads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
        {
            return await _context.leads.ToListAsync();
        }

        
        // GET: api/Leads/30days
        [HttpGet("30days")]
        public async Task<ActionResult<List<Lead>>> GetLead()
        {
            var allLeads = await _context.leads.Where(l => l.customer_id == null).ToListAsync();
            var newLeads = allLeads.Where(e => e.created_at >= DateTime.Today.AddDays(-30)).ToList();
            return newLeads;
        }
    }
}