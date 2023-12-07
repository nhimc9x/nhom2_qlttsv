using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using quanlythongtinsinhvien.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace quanlythongtinsinhvien.Controllers
{
    public class AdminController : Controller
    {
        QuanlysinhvienContextTest db_students = new QuanlysinhvienContextTest();

        private string KT_MA = "";

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

        // Test Conn
        public IActionResult Detailmajors()
        {
            var listMajors = db_students.Majors.ToList();
            return View(listMajors);
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

        private bool IsMaNganhExists(string Manganh)
        {
            return db_students.Majors.Any(sv => sv.Manganh == Manganh);
        }

        // Thêm sinh viên
        [Route("Themthongtin")]
        [HttpGet]
        public IActionResult Themthongtin()
        {
            // Lấy danh sách các tên ngành từ bảng majors
            var majorNames = db_students.Majors.Select(m => m.Tennganh).ToList();

            // Truyền danh sách này đến View bằng ViewBag hoặc ViewModel
            ViewBag.MajorNames = new SelectList(majorNames);

            return View();

        }

        [Route("Themthongtin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Themthongtin(StudentTest student)
        {
            if (db_students.Students.Any(s => s.Masv == student.Masv))
            {
                ModelState.AddModelError("Masv", "Mã sinh viên đã tồn tại.");
            }

            if (ModelState.IsValid)
            {
                db_students.Students.Add(student);
                db_students.SaveChanges();
                return RedirectToAction("Index");
            }
            // Nếu có lỗi, hiển thị form lại với thông báo lỗi
            ViewBag.MajorNames = new SelectList(db_students.Majors.Select(m => m.Tennganh).ToList());
            return View(student);
        }

        // Thêm ngành học
        [Route("Themnganhhoc")]
        [HttpGet]
        public IActionResult Themnganhhoc()
        {
            return View();
        }

        [Route("Themnganhhoc")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Themnganhhoc(MajorTest major)
        {
            TempData["Message"] = null;
            if (ModelState.IsValid)
            {
                // Kiểm tra mã sinh viên có trùng hay không
                if (IsMaNganhExists(major.Manganh))
                {
                    TempData["Message"] = "Mã ngành đã tồn tại, vui lòng nhập mã khác!";
                    return View(major); // Hiển thị trang với thông báo lỗi
                }
                db_students.Majors.Add(major);
                db_students.SaveChanges();
                return RedirectToAction("Detailmajors");
            }
            return View(major);
        }

        // Sửa sinh viên
        [Route("Suathongtin")]
        [HttpGet]
        public IActionResult Suathongtin(string Masv)
        {
            // Lấy danh sách các tên ngành từ bảng majors
            var majorNames = db_students.Majors.Select(m => m.Tennganh).ToList();

            // Truyền danh sách này đến View bằng ViewBag hoặc ViewModel
            ViewBag.MajorNames = new SelectList(majorNames);

            var editStudent = db_students.Students.Find(Masv);
            return View(editStudent);
        }

        [Route("Suathongtin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Suathongtin(StudentTest student)
        {
            
            if (ModelState.IsValid)
            {
                db_students.Update(student);
                db_students.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MajorNames = new SelectList(db_students.Majors.Select(m => m.Tennganh).ToList());
            return View(student);
        }

        // Sửa ngành học
        [Route("Suanganhhoc")]
        [HttpGet]
        public IActionResult Suanganhhoc(int id)
        {
            var editMajors = db_students.Majors.Find(id);
            return View(editMajors);
        }

        [Route("Suanganhhoc")]
        [HttpPost]
        public IActionResult Suanganhhoc(MajorTest major)
        {
            int ktID = major.Id;
            KT_MA = db_students.Majors.Where(m => m.Id == ktID).Select(m => m.Manganh).FirstOrDefault();

            if (KT_MA != major.Manganh)
            {
                // Kiểm tra mã sinh viên có trùng hay không
                if (IsMaNganhExists(major.Manganh))
                {
                    TempData["Message"] = "Mã ngành đã tồn tại, vui lòng nhập mã khác!";
                    return View(major); // Hiển thị trang với thông báo lỗi
                }
            }

            if (ModelState.IsValid)
            {
                db_students.Update(major);
                db_students.SaveChanges();
                return RedirectToAction("Detailmajors");
            }
            return View(major);
        }

        // Xóa sinh viên
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

        // Xóa ngành học
        [Route("Xoanganhhoc")]
        [HttpGet]
        public IActionResult Xoanganhhoc(int id)
        {
            TempData["Message"] = null;
            db_students.Remove(db_students.Majors.Find(id));
            db_students.SaveChanges();
            TempData["Message"] = "Xóa ngành thành công!";
            return RedirectToAction("Detailmajors");
        }
    }
}