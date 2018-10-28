using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVidly.Models;
using NewVidly.ViewModel;

namespace NewVidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers/ViewCustomers

        [Route("Customers/ViewCustomers")]
        public ActionResult ViewCustomers()
        {

            var customers = GetCustomers();
            var viewmodel = new RandomMovieViewModel()
            {
                Customers = customers.ToList()
            };

            return View(viewmodel);

        }

        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer{Id=1, Name="John Smith"},
                new Customer{Id  =2,Name="Mary Williams"}
            };

            return customers;


        }


        [Route("Customers/Detail/{id}")]
        public ActionResult Detail(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer is null) return HttpNotFound();
            return Content(customer.Name);
        }
    }
}