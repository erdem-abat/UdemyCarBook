using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {
            ViewBag.v = v;
            return View();
        }
    }
}
