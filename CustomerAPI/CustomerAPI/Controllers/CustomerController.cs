using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Models;

namespace CustomerAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerAPIDBContext _context;

        public CustomerController(CustomerAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var response = new Response();
            try
            {
                var customers = await _context.Customers.ToListAsync();
                response.StatusCode = 200;
                response.StatusDescription = "Call succeeds because database has data";
                response.Data = customers;
                return Ok(response);
            }
            catch(Exception)
            {
                response.StatusCode = 500;
                response.StatusDescription = "There was an internal error, please contact to technical support";
                return BadRequest(response);
            }
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            var response = new Response();

            if (customer == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Call fails because data not found";
                return NotFound(response);
            }
            response.StatusCode = 200;
            response.StatusDescription = "Call succeeds because data found";
            response.Data = customer;
            return Ok(response);
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            var response = new Response();

            if (id != customer.CustomerID)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Call fails because ID and CustomerID don't match";
                return BadRequest(response);
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
                    response.StatusCode = 404;
                    response.StatusDescription = "Call fails because data not found";
                    return NotFound(response);
                }
                else
                {
                    throw;
                }
            }
            response.StatusCode = 200;
            response.StatusDescription = "Call succeeds because data updated successfully";
            return Ok(response);
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            var response = new Response();
            if (CustomerExists(customer.CustomerID))
            {
                response.StatusCode = 400;
                response.StatusDescription = "Call fails because ID already existed";
                return BadRequest(response);
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerID }, new Response { 
                StatusCode = 201, 
                StatusDescription = "Call succeeds because customer is created",
                Data = customer 
            });
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            var response = new Response();
            //var customer = await _context.Customers.Include(c => c.Order).FirstOrDefaultAsync(
            //    c => c.CustomerID == id);


            if (customer == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Call fails because data not found";
                return NotFound(response);
            }

            _context.Customers.Remove(customer);

            //var order = await _context.Orders.FirstOrDefaultAsync(e => e.OrderID == customer.Order.OrderID);

            //_context.Orders.Remove(order);

            await _context.SaveChangesAsync();

            response.StatusCode = 200;
            response.StatusDescription = "Call succeeds because data is deleted successfully";
            return Ok(response);
        }

        [HttpGet("{id}/order")]
        public async Task<ActionResult<Customer>> GetCustomerOrder(int id)
        {
            var response = new Response();

            var customer = await _context.Customers.Include(c => c.Order).FirstOrDefaultAsync(
                c => c.CustomerID == id);

            if (customer == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Call fails because customer does not exist";
                return BadRequest(response);
            }

            var order = await _context.Orders.FirstOrDefaultAsync(e => e.OrderID == customer.Order.OrderID);

            response.StatusCode = 200;
            response.StatusDescription = "Call succeeds because order is not null";
            response.Data = order;
            return Ok(response);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
