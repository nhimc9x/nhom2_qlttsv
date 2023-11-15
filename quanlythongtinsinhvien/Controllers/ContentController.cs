using Microsoft.AspNetCore.Mvc;
using quanlythongtinsinhvien.Models;
using System.Diagnostics;

namespace quanlythongtinsinhvien.Controllers
{
    public class ContentController : Controller
    {
        private readonly ILogger<ContentController> _logger;

        public ContentController(ILogger<ContentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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
