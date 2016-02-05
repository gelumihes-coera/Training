using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOLIDapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ingredients()
        {
            return RedirectToAction("IngredientIndex", "Ingredient");
        }

        public ActionResult Products()
        {
            return RedirectToAction("ProductIndex", "Product");
        }

        public ActionResult Customers()
        {
            return RedirectToAction("CustomerIndex", "Customer");
        }
    }
}