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
    public class CustomersController : ControllerBase
    {
        private readonly RestAPIContext _context;

        public CustomersController(RestAPIContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Getcustomers()
        {
            return await _context.customers.ToListAsync();
        }

//------------------------------ Retrieving just Info of Customer using the e-mail -------------------------------\\

        //GET: api/Customers/email
        [HttpGet("{email}")]
        public object GetEmailCustomer(string email)
        {
            var customer = _context.customers.Where(e=>e.cpy_contact_email == email);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

//--------- Retrieving all Info of Customer (Building, Battery, Columns and Elevators) using the e-mail ---------\\

        //GET: api/Customers/FullInfo/email
        [HttpGet("FullInfo/{email}")]
        public async Task<ActionResult<Customer>> GetCustomer(string email)
        {
            
            var customer = await _context.customers.Include("Buildings.Batteries.Columns.Elevators")
                                                    .Where(c => c.cpy_contact_email == email)
                                                    .FirstOrDefaultAsync();                     

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }        

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            if (id != customer.id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        private bool CustomerExists(long id)
        {
            return _context.customers.Any(e => e.id == id);
        }
    }
}
