using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UdemyCarBook.Dto.BrandsDto;
using UdemyCarBook.Dto.LocationDtos;
using UdemyCarBook.Dto.RentACarDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var bookPickDate = TempData["bookPickDate"];
            var bookOffDate = TempData["bookOffDate"];
            var timePick = TempData["timePick"];
            var timeOff = TempData["timeOff"];
            var locationID = TempData["locationID"];

            ViewBag.bookPickDate = bookPickDate;
            ViewBag.bookOffDate = bookOffDate;
            ViewBag.timePick = timePick;
            ViewBag.timeOff = timeOff;
            ViewBag.locationID = locationID;

            int id = int.Parse(locationID.ToString());

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7091/api/RentACars?locationId={id}&available=true");           
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
