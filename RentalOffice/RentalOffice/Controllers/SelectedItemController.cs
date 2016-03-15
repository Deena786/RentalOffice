using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalOffice.Model;
using RentalOffice.Service;
using RentalOffice.Service.Implementation;
using System.Security.Principal;
using System.Web.Security;

namespace RentalOffice.Controllers
{
    public class SelectedItemController : Controller
    {
        private readonly IProductService productService = ServiceLocator.GetProductService();
        private readonly ISelectedItemService selectedItemService = ServiceLocator.GetSelectedItemService();
        private readonly IUserService userService = ServiceLocator.GetUserService();

        

        //~~~~~~~~~~~~~~~~~~~~~ Добавление выбранных фильмов ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public ActionResult AddSelectedItem(int id)
        {
            string userLog = GenericPrincipal.Current.Identity.Name;
            var user = userService.GetUserByLogin(userLog);
            selectedItemService.AddItem(id, user.UserId);        

            return RedirectToAction("ListForUser", "Product");
        }

        public ViewResult ShowSelectedItem()
        {
            string userLog = GenericPrincipal.Current.Identity.Name;
            var user = userService.GetUserByLogin(userLog);
            var model = selectedItemService.GetItemsByUserIdForShow(user.UserId);
            if(model.Count() != 0)
            {
                return View("ShowSelectedItem", model);
            }
            return View("EmptySelectedItem");
        }

        //~~~~~~~~~~~~~~~~~~~~~ DELETE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [HttpGet]
        public ActionResult DeleteSelectedItem(int id)
        {            
            selectedItemService.DeleteItem(id);
            return RedirectToAction("ShowSelectedItem");
        }
        
    }
}
