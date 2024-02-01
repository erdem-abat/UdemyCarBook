using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CommentDtos;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7091/api/Blogs/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultBlogById>(jsonData);

            var client2 = _httpClientFactory.CreateClient();
            var responseCommentCountMessage = await client2.GetAsync($"https://localhost:7091/api/Comments/CommentCountByBlog?id=" + id);
            var jsonCommentCountData = await responseCommentCountMessage.Content.ReadAsStringAsync();

            ViewBag.CommentCount = jsonCommentCountData;

            return View(values);
        }
    }
}
