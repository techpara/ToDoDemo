using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;
using ToDoDemo.Data;
using ToDoDemo.Models;
namespace ToDoDemo.UI.Pages
{
    public class HomeModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeModel(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

         public List<ToDoResponse> allTodo = new List<ToDoResponse>();

        public async Task OnGetAsync()
        {
            var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "https://localhost:7221/api/todo/get");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                allTodo = await JsonSerializer.DeserializeAsync
                    <List<ToDoResponse>>(contentStream);
            }
        }
    }
}
