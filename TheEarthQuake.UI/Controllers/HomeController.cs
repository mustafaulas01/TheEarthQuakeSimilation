using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TheEarthQuake.UI.Models;

namespace TheEarthQuake.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public async Task<IActionResult> GetAsync()
        {
            string url = "https://hublabs.com.tr/api/tr-earthquakes";

            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<JsonModelView>(response);


            return Json(json);
        }


        public IActionResult Map()
        {

            return View();
        }
      
        public IActionResult Index()
        {//bu daha yüklendiğinde script çalışmadığı iiçin hata verir. yüklendiğinde otomatik gelecek şekilde revize yap
            var datam = GetAsync();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}