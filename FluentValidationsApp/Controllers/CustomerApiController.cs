using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidationsApp.Models;
using FluentValidationsApp.Models.Data;
using FluentValidation;
using AutoMapper;
using FluentValidationsApp.DTOS;
using Microsoft.AspNetCore.Routing;

namespace FluentValidationsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IValidator<Customer> _customerValidator;
        private readonly IMapper mapper;

        public CustomerApiController(AppDbContext context, IValidator<Customer> customerValidator, IMapper mapper)
        {
            _context = context;
            _customerValidator = customerValidator;
            this.mapper = mapper;
        }

        [Route("/Mappex")]
        [HttpGet]
        public async Task<IActionResult> MapeEx()
        {
            return await Task.Run(() => Ok(mapper.Map<CustomerDtoDN>(new Customer()
            {
                Id = 1,
                Name = "asd",
                Age = 5,
                BirthDate = DateTime.Now.Date,
                Email = "asd@mail.com",

            })));
        }

        // GET: api/CustomerApi
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(mapper.Map<List<CustomerDto>>(source: customers));
            //return Ok(mapper.Map<List<CustomerDtoDN>>(source: customers));

        }

        // GET: api/CustomerApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/CustomerApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
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

        // POST: api/CustomerApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            var validationResult = _customerValidator.Validate(customer);
            if (!validationResult.IsValid)
                return BadRequest(
                    validationResult.Errors.Select(x => new { x.PropertyName, x.ErrorMessage, x.ErrorCode, x.ResourceName, x.Severity }));

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/CustomerApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
