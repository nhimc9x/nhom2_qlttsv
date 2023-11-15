using Microsoft.AspNetCore.Mvc;
using quanlythongtinsinhvien.Models;
using System.Diagnostics;

namespace quanlythongtinsinhvien.Controllers
{
    public class ContentController : Controller
    {
        QuanlysinhvienContext db_students = new QuanlysinhvienContext();
        private readonly ILogger<ContentController> _logger;

        public ContentController(ILogger<ContentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listSudents = db_students.Students.ToList();
            return View(listSudents);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
