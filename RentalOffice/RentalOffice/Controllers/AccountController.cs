using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RentalOffice.Model;
using RentalOffice.Service;
using System.Web.Routing;

namespace RentalOffice.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService = ServiceLocator.GetUserService();

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult Login(UserViewModel model)
        {
            var currentUser = userService.GetUserByLoginPassword(model.Login, model.Password);
            if (currentUser != null)
            {
                //////////////////////////////////////////////////////////
                  var authTicket = new FormsAuthenticationTicket(
                      1,                             // version
                      currentUser.Login,                      // user name
                      DateTime.Now,                  // created
                      DateTime.Now.AddMinutes(30),   // expires
                      true,                    // persistent?
                      ((RentalOffice.Data.Entities.Roles)currentUser.Role).ToString() // can be used to store roles
                  );

                  string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                  var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                  HttpContext.Response.Cookies.Add(authCookie);
                  /////////////////////////////////////////////////////////////////

                
                  switch ((RentalOffice.Data.Entities.Roles)currentUser.Role)
                  {
                      case RentalOffice.Data.Entities.Roles.Customer:
                          return RedirectToAction("ListForUser", "Product");
                      //return RedirectToAction("Index", "Students", new RouteValueDictionary(currentUser));
                      //return View("~/Views/Students/Index.cshtml", currentUser);

                      case RentalOffice.Data.Entities.Roles.Admin:
                          return RedirectToAction("Index", "Admin");                     


                      case RentalOffice.Data.Entities.Roles.Employee:
                          return RedirectToAction("About", "Home");


                      default:
                          return RedirectToAction("About", "Home");
                  }                
            }
            else
            {
                ModelState.AddModelError("", "Неправильно указан логин или пароль");
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegistrViewModel model)
        {
            if (ModelState.IsValid) 
            {
                userService.CreateUser(model);

                return RedirectToAction("Login");
            }
            return View(model);
        }


    }
}
