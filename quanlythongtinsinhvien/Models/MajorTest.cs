using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace quanlythongtinsinhvien.Models;

public partial class MajorTest
{
    [Display(Name = "_Id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Thiếu mã ngành")]
    [Display(Name = "Mã ngành")]
    public string Manganh { get; set; } = null!;

    [Required(ErrorMessage = "Thiếu tên ngành")]
    [Display(Name = "Tên ngành")]
    public string Tennganh { get; set; } = null!;
}
