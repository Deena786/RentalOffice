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
    public class ProductController : Controller
    {
        private readonly IProductService productService = ServiceLocator.GetProductService();
        private readonly IUserService userService = ServiceLocator.GetUserService();

        public ActionResult List()
        {
            return View(productService.GetAllProducts().ToList());
        }

        public ActionResult ListForUser(string searchString)
        {
            string userLog = GenericPrincipal.Current.Identity.Name;           
            var user = userService.GetUserByLogin(userLog);
            ViewBag.UserName = user.Name + " " + user.Surname;
            var model = new List<ProductViewModel>();
            if (!String.IsNullOrEmpty(searchString))
            {
                model = productService.GetProductByName(searchString).ToList();
            }
            else
            {
                model = productService.GetAllProducts().ToList();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult ListForUserByCategory(string id)
        {
            string userLog = GenericPrincipal.Current.Identity.Name;
            var user = userService.GetUserByLogin(userLog);
            ViewBag.UserName = user.Name + " " + user.Surname;
            var model = productService.GetProductByCategory(id).ToList();
            return View(model);
        }


//~~~~~~~~~~~~~~~~~~~~~ CREATE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model = new ProductViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                productService.CreateProduct(model);
                return RedirectToAction("List");
            }
            return View(model);
        }


//~~~~~~~~~~~~~~~~~~~~~ UPDATE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [HttpGet]
        [Authorize(Roles="Admin")]
        public ActionResult Update(int id)
        {
            var model = productService.GetProduct(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                productService.UpdateProduct(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

//~~~~~~~~~~~~~~~~~~~~~ DELETE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            productService.DeleteProduct(id);
            return RedirectToAction("List");
        }

//~~~~~~~~~~~~~~~~~~~~~ Search ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

      /*  public ActionResult Search(string searchString)
        {

        }*/
    }
}
