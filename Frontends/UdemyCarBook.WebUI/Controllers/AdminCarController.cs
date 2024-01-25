using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.BrandsDto;
using UdemyCarBook.Dto.CarDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7091/api/Cars/GetCarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7091/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                List<SelectListItem> brandValues = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.BrandID.ToString()
                                                    }).ToList();
                ViewBag.BrandValues = brandValues;
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7091/api/Cars", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var client2 = _httpClientFactory.CreateClient();
                var brandValuesresponseMessage = await client2.GetAsync("https://localhost:7091/api/Brands");
                if (brandValuesresponseMessage.IsSuccessStatusCode)
                {
                    var brandValuesjsonData = await brandValuesresponseMessage.Content.ReadAsStringAsync();
                    var brandValues = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandValuesjsonData);
                    List<SelectListItem> brandValuesList = (from x in brandValues
                                                            select new SelectListItem
                                                            {
                                                                Text = x.Name,
                                                                Value = x.BrandID.ToString()
                                                            }).ToList();
                    ViewBag.BrandValues = brandValuesList;
                    return View();
                }
                return View();
            }
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7091/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {

            var client = _httpClientFactory.CreateClient();

            var brandValuesresponseMessage = await client.GetAsync("https://localhost:7091/api/Brands");

            var brandValuesjsonData = await brandValuesresponseMessage.Content.ReadAsStringAsync();
            var brandValues = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandValuesjsonData);
            List<SelectListItem> brandValuesList = (from x in brandValues
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.BrandID.ToString()
                                                    }).ToList();
            ViewBag.BrandValues = brandValuesList;

            var responseMessage = await client.GetAsync($"https://localhost:7091/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);

                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7091/api/Cars", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var client2 = _httpClientFactory.CreateClient();
                var brandValuesresponseMessage = await client2.GetAsync("https://localhost:7091/api/Brands");
                if (brandValuesresponseMessage.IsSuccessStatusCode)
                {
                    var brandValuesjsonData = await brandValuesresponseMessage.Content.ReadAsStringAsync();
                    var brandValues = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandValuesjsonData);
                    List<SelectListItem> brandValuesList = (from x in brandValues
                                                            select new SelectListItem
                                                            {
                                                                Text = x.Name,
                                                                Value = x.BrandID.ToString()
                                                            }).ToList();
                    ViewBag.BrandValues = brandValuesList;
                    return View();
                }
                return View();
            }
        }
    }
}
