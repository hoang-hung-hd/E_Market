using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web_Client.Models;

namespace Web_Client.Controllers
{
    public class CategoryController : Controller
    {
        private const string baseUrl = "https://localhost:7036";
        public async Task<IActionResult> Index()
        {

            IEnumerable<CategoryModel> users = await CallConnectToApi<List<CategoryModel>>(HttpMethod.Get, "/Category");
            return View(users);
        }
        public async Task<ActionResult> Details(int id)
        {
            CategoryModel category = await CallConnectToApi<CategoryModel>(HttpMethod.Get, "/Category/" + id);
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel user)
        {

            HttpContent content = new StringContent(JsonSerializer.Serialize(user), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await CallConnectToApi(HttpMethod.Post, "/Category/", content);
            return RedirectToAction(nameof(Index));

        }
        public async Task<ActionResult> Edit(int id)
        {
            CategoryModel category = await CallConnectToApi<CategoryModel>(HttpMethod.Get, "/Category/" + id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CategoryModel category)
        {
            try
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(category), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await CallConnectToApi(HttpMethod.Put, "/Category/" + id, content);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Delete(int id)
        {
            CategoryModel category = await CallConnectToApi<CategoryModel>(HttpMethod.Get, "/Category/" + id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                HttpResponseMessage response = await CallConnectToApi(HttpMethod.Delete, "/Category/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<T> CallConnectToApi<T>(HttpMethod method, string pathUrl, HttpContent content = null)
        {
            try
            {
                var rs = await CallConnectToApi(method, pathUrl, content);
                return await rs.Content.ReadFromJsonAsync<T>();
            }
            catch
            {
                return default(T);
            }
        }

        public async Task<HttpResponseMessage> CallConnectToApi(HttpMethod method, string pathUrl, HttpContent content = null)
        {

            HttpRequestMessage request = new HttpRequestMessage(method, pathUrl);
            if (content != null)
            {
                request.Content = content;
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            return await client.SendAsync(request);
        }
    }
}
