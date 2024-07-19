using EnviarMultiplosIDs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EnviarMultiplosIDs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        [HttpPost]
        public JsonResult SeuMetodo([FromBody] int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return Json(new { success = false, message = "Nenhum ID foi recebido." });
            }

            // Processar os IDs
            foreach (var id in ids)
            {
                System.Diagnostics.Debug.WriteLine("ID recebido: " + id);
            }

            return Json(new { success = true, receivedIds = ids });
        }

    }
}
