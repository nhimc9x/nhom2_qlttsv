using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quanlythongtinsinhvien.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace quanlythongtinsinhvien.Controllers
{
    public class AdminController : Controller
    {
        QuanlysinhvienContext db_students = new QuanlysinhvienContext();

        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
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

        // Test
        private bool IsMaSinhVienExists(string Masv)
        {
            return db_students.Students.Any(sv => sv.Masv == Masv);
        }

        // Thêm 
        [Route("Themthongtin")]
        [HttpGet]
        public IActionResult Themthongtin()
        {
            return View();
        }

        [Route("Themthongtin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Themthongtin(Student student)
        {
            TempData["Message"] = null;
            if (ModelState.IsValid)
            {
                // Kiểm tra mã sinh viên có trùng hay không
                if (IsMaSinhVienExists(student.Masv))
                {
                    TempData["Message"] = "Mã sinh viên đã tồn tại, vui lòng nhập mã khác!";
                    return View(student); // Hiển thị trang với thông báo lỗi
                }
                db_students.Students.Add(student);
                db_students.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Sửa
        [Route("Suathongtin")]
        [HttpGet]
        public IActionResult Suathongtin(string Masv)
        {
            var editStudent = db_students.Students.Find(Masv);
            return View(editStudent);
        }

        [Route("Suathongtin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Suathongtin(Student student)
        {
            TempData["Message"] = null;
            if (ModelState.IsValid)
            {
                db_students.Update(student);
                db_students.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Xóa 
        [Route("Xoathongtin")]
        [HttpGet]
        public IActionResult Xoathongtin(string Masv)
        {
            TempData["Message"] = null;
            db_students.Remove(db_students.Students.Find(Masv));
            db_students.SaveChanges();
            TempData["Message"] = "Xóa sinh viên " + Masv +" thành công!";
            return RedirectToAction("Index");
        }
    }
}