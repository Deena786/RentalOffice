using System.Web.Mvc;
using RentalOffice.Service;
using RentalOffice.Model;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Security.Principal;
using System.Web.Security;

namespace RentalOffice.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService = ServiceLocator.GetUserService();

        public ActionResult Index()
        {
            string userLog = GenericPrincipal.Current.Identity.Name;
            //var model = userService.GetUserByLogin(userLog);
            var user = userService.GetUserByLogin(userLog);
            ViewBag.UserName = user.Name + " " + user.Surname;
            
            return View();
        }

        public ViewResult List()
        {
            return View(userService.GetAllUsers().ToList());
        }

       

        //~~~~~~~~~~~~~~  CREATE  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [HttpGet]
        public ViewResult Create()
        {
            var model = new UserViewModel();
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            if(ModelState.IsValid)
            {
                userService.CreateUserByAdmin(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

        //~~~~~~~~~~~~~~~~  Update  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        [HttpGet]
        public ViewResult Update(int id)
        {
            var model = userService.GetUser(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UserViewModel model)
        {
            if(ModelState.IsValid)
            {
                userService.UpdateUser(model);
                return RedirectToAction("List");
            }
            return View(model);
        }
    }
}
