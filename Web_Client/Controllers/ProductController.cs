using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Web_Client.Models;

namespace Web_Client.Controllers
{
    public class ProductController : Controller
    {
        private const string baseUrl = "https://localhost:7036";
        public async Task<IActionResult> Index()
        {

            IEnumerable<ProductModel> users = await CallConnectToApi<List<ProductModel>>(HttpMethod.Get, "/Product");
            return View(users);
        }
        public async Task<ActionResult> Details(int id)
        {
            ProductModel product = await CallConnectToApi<ProductModel>(HttpMethod.Get, "/Product/" + id);
            return View(product);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel user)
        {

            HttpContent content = new StringContent(JsonSerializer.Serialize(user), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await CallConnectToApi(HttpMethod.Post, "/Product/", content);
            return RedirectToAction(nameof(Index));

        }
        public async Task<ActionResult> Edit(int id)
        {
            ProductModel product = await CallConnectToApi<ProductModel>(HttpMethod.Get, "/Product/" + id);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductModel product)
        {
            try
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(product), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await CallConnectToApi(HttpMethod.Put, "/Product/" + id, content);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Delete(int id)
        {
            ProductModel product = await CallConnectToApi<ProductModel>(HttpMethod.Get, "/Product/" + id);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                HttpResponseMessage response = await CallConnectToApi(HttpMethod.Delete, "/Product/" + id);
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
