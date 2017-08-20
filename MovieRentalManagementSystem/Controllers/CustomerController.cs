using MovieRentalManagementSystem.Models;
using MovieRentalManagementSystem.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MovieRentalManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var memberShipTypes = _context.MembershipTypes.ToList();
            var newCustomerViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = memberShipTypes
            };
            return View("CustomerForm", newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var customeViewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", customeViewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerFound = _context.Customers.Single(s => s.Id == customer.Id);

                customerFound.Name = customer.Name;
                customerFound.IsSubscribedToNewsLetter = customerFound.IsSubscribedToNewsLetter;
                customerFound.BirthDay = customer.BirthDay;
                customerFound.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        // GET: Customer
        public ActionResult Index()
        {

            var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customer);
        }
        public ActionResult Details(int id)
        {
            {

                var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customer == null)
                    return HttpNotFound();

                return View(customer);

            }
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(s => s.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viweModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viweModel);
        }
    }
}