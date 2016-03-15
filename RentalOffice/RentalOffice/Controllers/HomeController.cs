using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalOffice.Model;
using RentalOffice.Service;
using RentalOffice.Service.Implementation;

namespace RentalOffice.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService = ServiceLocator.GetProductService();

        public ActionResult Index()
        {
            return View(productService.GetAllProducts().ToList());
        }

        public ViewResult List()
        {
            return View(productService.GetAllProducts().ToList());
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult AboutForUser()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }

        public ViewResult ContactForUser()
        {
            return View();
        }

        public ViewResult Discounts()
        {
            return View();
        }

        public ViewResult RegularClients()
        {
            return View();
        }
    }
}
