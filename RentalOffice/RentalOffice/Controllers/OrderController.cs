using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentalOffice.Model;
using RentalOffice.Service;
using RentalOffice.Service.Implementation;
using System.Security.Principal;

namespace RentalOffice.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService = ServiceLocator.GetOrderService();
        private readonly ISelectedItemService selectedItemService = ServiceLocator.GetSelectedItemService();
        private readonly IUserService userService = ServiceLocator.GetUserService();
        //private readonly IAddressService addressService = ServiceLocator.ge

        public ActionResult List()
        {
            return View(orderService.GetAllOrders().ToList());
        }

//~~~~~~~~~~~~~~~~~~~~~ Заказы, поступившие сегодня ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ActionResult ListTodey()
        {
            return View(orderService.GetOrderDate(DateTime.Today).ToList());
        }

//~~~~~~~~~~~~~~~~~~~~~ CREATE (User)~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [HttpGet]
        public ActionResult CreateOrderByUser(int id)
        {
            string userLog = GenericPrincipal.Current.Identity.Name;
            var user = userService.GetUserByLogin(userLog);
            return View(orderService.GetNewOrder(user.UserId));
        }

        [HttpPost]
        public ActionResult CreateOrderByUser( OrderViewModel model)
        {
            string userLog = GenericPrincipal.Current.Identity.Name;
            var user = userService.GetUserByLogin(userLog);
            model.UserId = user.UserId;

            if (ModelState.IsValid)
            {
                orderService.CreateOrder(model);
                return RedirectToAction("ThanksForOrder"); 
            }
            return View(model);
        }

//~~~~~~~~~~~~~~~~~~~~~ THANKS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public ViewResult ThanksForOrder()
        {
            return View();
        }

//~~~~~~~~~~~~~~~~~~~~~ Личный кабинет~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ViewResult UserOrders()
        {
            string userLog = GenericPrincipal.Current.Identity.Name;
            var user = userService.GetUserByLogin(userLog);
            var model = orderService.GetUserOrders(user.UserId);
            return View(model);
        }

//~~~~~~~~~~~~~~~~~~~~~ CREATE (Admin)~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [HttpGet]
        public ActionResult CreateOrder()
        {
            var model = new OrderViewModel();
            model.OrderDate = DateTime.Now;
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderViewModel model)
        {
            if(ModelState.IsValid)
            {
                orderService.CreateOrder(model);
                return RedirectToAction("List");
            }
            return View(model);
        }


//~~~~~~~~~~~~~~~~~~~~~ UPDATE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [HttpGet]
        public ActionResult UpdateOrder(int id)
        {
            var model = orderService.GetOrder(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateOrder(OrderViewModel model)
        {
            if(ModelState.IsValid)
            {
                orderService.UpdateOrder(model);
                return RedirectToAction("List");
            }
            return View(model);
        }
    }
}
