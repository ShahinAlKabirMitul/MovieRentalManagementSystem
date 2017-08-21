using AutoMapper;
using MovieRentalManagementSystem.Dtos;
using MovieRentalManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MovieRentalManagementSystem.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _dbContext.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(s => s.Id == id);
            if (customer == null)
            {
                new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerDb = _dbContext.Customers.SingleOrDefault(s => s.Id == id);
            if (customerDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerDb);

            _dbContext.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerDb = _dbContext.Customers.SingleOrDefault(s => s.Id == id);
            if (customerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _dbContext.Customers.Remove(customerDb);
            _dbContext.SaveChanges();

        }

    }
}
