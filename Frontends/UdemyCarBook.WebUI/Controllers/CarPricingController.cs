using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Packages";
            ViewBag.v2 = "Car Packages";
            return View();
        }
    }
}
