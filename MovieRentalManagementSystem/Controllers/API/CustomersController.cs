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

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(s => s.Id == id);
            if (customer == null)
            {
                new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerDb = _dbContext.Customers.SingleOrDefault(s => s.Id == id);
            if (customerDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            customerDb.Name = customer.Name;
            customerDb.BirthDay = customer.BirthDay;
            customerDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerDb.MembershipTypeId = customer.MembershipTypeId;
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
