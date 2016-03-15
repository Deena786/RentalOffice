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
    public class OrderItemController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        

    }
}
