using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AuthorDtos;
using UdemyCarBook.Dto.StatisticsDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            #region CarCount
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7091/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v = values.carCount;
            }
            #endregion

            #region GetLocation
            var rMGetLocation = await client.GetAsync("https://localhost:7091/api/Statistics/GetLocationCount");
            if (rMGetLocation.IsSuccessStatusCode)
            {

                var jsonData = await rMGetLocation.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.vGetLocation = values.locationCount;
            }
            #endregion

            #region GetAuthorCount
            var rMAuthorCount = await client.GetAsync("https://localhost:7091/api/Statistics/GetAuthorCount");
            if (rMAuthorCount.IsSuccessStatusCode)
            {

                var jsonData = await rMAuthorCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.vGetAuthorCount = values.authorCount;
            }
            #endregion

            #region GetBlogCount
            var rMBlogCount = await client.GetAsync("https://localhost:7091/api/Statistics/GetBlogCount");
            if (rMBlogCount.IsSuccessStatusCode)
            {

                var jsonData = await rMBlogCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.vGetBlogCount = values.blogCount;
            }
            #endregion

            #region GetBrandCount
            var rMBrandCount = await client.GetAsync("https://localhost:7091/api/Statistics/GetBrandCount");
            if (rMBrandCount.IsSuccessStatusCode)
            {

                var jsonData = await rMBrandCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.vGetBrandCount = values.brandCount;
            }
            #endregion

            #region GetAvgRentPriceForDaily
            var rMAvgRentPriceForDaily = await client.GetAsync("https://localhost:7091/api/Statistics/GetAvgRentPriceForDaily");
            if (rMAvgRentPriceForDaily.IsSuccessStatusCode)
            {
                var jsonData = await rMAvgRentPriceForDaily.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.vGetAvgRentPriceForDaily = values.avgRentPriceForDaily;
            }
            #endregion

            #region GetAvgRentPriceForWeekly
            var rMAvgRentPriceForWeekly = await client.GetAsync("https://localhost:7091/api/Statistics/GetAvgRentPriceForWeekly");
            if (rMAvgRentPriceForWeekly.IsSuccessStatusCode)
            {
                var jsonData = await rMAvgRentPriceForWeekly.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.vGetAvgRentPriceForWeekly = values.avgRentPriceForWeekly;
            }
            #endregion

            #region GetAvgRentPriceForMonthly
            var rMAvgRentPriceForMonthly = await client.GetAsync("https://localhost:7091/api/Statistics/GetAvgRentPriceForMonthly");
            if (rMAvgRentPriceForMonthly.IsSuccessStatusCode)
            {
                var jsonData = await rMAvgRentPriceForMonthly.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.vGetAvgRentPriceForMonthly = values.avgRentPriceForMonthly;
            }
            #endregion

            #region GetCarCountByTransmissionIsAuto
            var GetCarCountByTransmissionIsAuto = await client.GetAsync("https://localhost:7091/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (GetCarCountByTransmissionIsAuto.IsSuccessStatusCode)
            {
                var jsonData = await GetCarCountByTransmissionIsAuto.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.GetCarCountByTransmissionIsAuto = values.carCountByTransmissionIsAuto;
            }
            #endregion

            #region GetBrandNameByMaxCar
            var GetBrandNameByMaxCar = await client.GetAsync("https://localhost:7091/api/Statistics/GetBrandNameByMaxCar");
            if (GetBrandNameByMaxCar.IsSuccessStatusCode)
            {
                var jsonData = await GetBrandNameByMaxCar.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.GetBrandNameByMaxCar = values.brandNameByMaxCar;
            }
            #endregion

            #region GetBlogTitleByMaxBlogComment
            var GetBlogTitleByMaxBlogComment = await client.GetAsync("https://localhost:7091/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (GetBlogTitleByMaxBlogComment.IsSuccessStatusCode)
            {
                var jsonData = await GetBlogTitleByMaxBlogComment.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.GetBlogTitleByMaxBlogComment = values.blogTitleByMaxBlogComment;
            }
            #endregion

            #region GetCarCountByKmLowerThen1000
            var GetCarCountByKmLowerThen1000 = await client.GetAsync("https://localhost:7091/api/Statistics/GetCarCountByKmLowerThen1000");
            if (GetCarCountByKmLowerThen1000.IsSuccessStatusCode)
            {
                var jsonData = await GetCarCountByKmLowerThen1000.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.GetCarCountByKmLowerThen1000 = values.carCountByKmLowerThen1000;
            }
            #endregion

            #region GetCarCountByFuelPetrolOrDiesel
            var GetCarCountByFuelPetrolOrDiesel = await client.GetAsync("https://localhost:7091/api/Statistics/GetCarCountByFuelPetrolOrDiesel");
            if (GetCarCountByFuelPetrolOrDiesel.IsSuccessStatusCode)
            {
                var jsonData = await GetCarCountByFuelPetrolOrDiesel.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.GetCarCountByFuelPetrolOrDiesel = values.carCountByFuelPetrolOrDiesel;
            }
            #endregion

            #region GetCarCountByFuelElectric
            var GetCarCountByFuelElectric = await client.GetAsync("https://localhost:7091/api/Statistics/GetCarCountByFuelElectric");
            if (GetCarCountByFuelElectric.IsSuccessStatusCode)
            {
                var jsonData = await GetCarCountByFuelElectric.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.GetCarCountByFuelElectric = values.carCountByFuelElectric;
            }
            #endregion

            #region GetCarBrandAndModelByRentPriceDailyMax
            var GetCarBrandAndModelByRentPriceDailyMax = await client.GetAsync("https://localhost:7091/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (GetCarBrandAndModelByRentPriceDailyMax.IsSuccessStatusCode)
            {
                var jsonData = await GetCarBrandAndModelByRentPriceDailyMax.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.GetCarBrandAndModelByRentPriceDailyMax = values.carBrandAndModelByRentPriceDailyMax;
            }
            #endregion

            #region GetCarBrandAndModelByRentPriceDailyMin
            var GetCarBrandAndModelByRentPriceDailyMin = await client.GetAsync("https://localhost:7091/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (GetCarBrandAndModelByRentPriceDailyMin.IsSuccessStatusCode)
            {
                var jsonData = await GetCarBrandAndModelByRentPriceDailyMin.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.GetCarBrandAndModelByRentPriceDailyMin = values.carBrandAndModelByRentPriceDailyMin;
            }
            #endregion

            return View();

        }
    }
}
