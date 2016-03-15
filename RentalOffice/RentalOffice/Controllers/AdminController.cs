using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using System.Web.Security;
using RentalOffice.Service;
using RentalOffice.Model;

namespace RentalOffice.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService userService = ServiceLocator.GetUserService(); 

        public ActionResult Index()
        {
            string userLog = GenericPrincipal.Current.Identity.Name;
            var model = userService.GetUserByLogin(userLog);
            return View(model);
        }

        public ViewResult Settings()
        {
            return View();
        }

        public ViewResult Delivery()
        {
            return View();
        }

        public ViewResult Administration()
        {
            return View();
        }

        public ViewResult Cashbox()
        {
            return View();
        }
    }
}
