using System;
using System.Collections.Generic;

namespace quanlythongtinsinhvien.Models;

public partial class Student
{
    public string Masv { get; set; } = null!;

    public string Tensv { get; set; } = null!;

    public string? Ngaysinh { get; set; }

    public string? Quequan { get; set; }

    public string? Sodienthoai { get; set; }

    public string? Ghichu { get; set; }

    public string? Gioitinh { get; set; }

    public int Id { get; set; }
}
