using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dto.StatisticsDtos;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region CarCount
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7091/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = values.carCount;
            }
            #endregion

            #region GetLocation
            var rMGetLocation = await client.GetAsync("https://localhost:7091/api/Statistics/GetLocationCount");
            if (rMGetLocation.IsSuccessStatusCode)
            {

                var jsonData = await rMGetLocation.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.locationCount = values.locationCount;
            }
            #endregion

            #region GetBrandCount
            var rMBrandCount = await client.GetAsync("https://localhost:7091/api/Statistics/GetBrandCount");
            if (rMBrandCount.IsSuccessStatusCode)
            {

                var jsonData = await rMBrandCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.brandCount = values.brandCount;
            }
            #endregion

            #region GetCarCountByFuelElectric
            var GetCarCountByFuelElectric = await client.GetAsync("https://localhost:7091/api/Statistics/GetCarCountByFuelElectric");
            if (GetCarCountByFuelElectric.IsSuccessStatusCode)
            {
                var jsonData = await GetCarCountByFuelElectric.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCountByFuelElectric = values.carCountByFuelElectric;
            }
            #endregion

            return View();
        }
    }
}
