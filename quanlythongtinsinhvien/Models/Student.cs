using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace quanlythongtinsinhvien.Models;

public partial class Student
{
    [Required(ErrorMessage = "Thiếu mã sinh viên")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Chiều dài không chính xác")]
    [Display(Name = "Mã sinh viên")]
    public string Masv { get; set; } = null!;

    [Required(ErrorMessage = "Thiếu mã sinh viên")]
    [Display(Name = "Tên sinh viên")]
    public string Tensv { get; set; } = null!;

    [Display(Name = "Ngày sinh (yyyy-mm-dd)")]
    public string? Ngaysinh { get; set; }

    [Display(Name = "Quê quán")]
    public string? Quequan { get; set; }

    [Display(Name = "Số điện thoại")]
    public string? Sodienthoai { get; set; }

    [Display(Name = "Thông tin thêm")]
    public string? Ghichu { get; set; }

    [Display(Name = "Giới tính")]
    public string? Gioitinh { get; set; }
}
