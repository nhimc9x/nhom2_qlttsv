using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace quanlythongtinsinhvien.Models;

public partial class QuanlysinhvienContextTest : DbContext
{
    public QuanlysinhvienContextTest()
    {
    }

    public QuanlysinhvienContextTest(DbContextOptions<QuanlysinhvienContextTest> options)
        : base(options)
    {
    }

    public virtual DbSet<MajorTest> Majors { get; set; }

    public virtual DbSet<StudentTest> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NHICOMPUTER\\WNSEVER;Initial Catalog=quanlysinhvien;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Vietnamese_100_CI_AS_KS_WS_SC_UTF8");

        modelBuilder.Entity<MajorTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__majors__3213E83FBBAD8C00");

            entity.ToTable("majors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Manganh)
                .HasMaxLength(20)
                .HasColumnName("manganh");
            entity.Property(e => e.Tennganh)
                .HasMaxLength(255)
                .HasColumnName("tennganh");
        });

        modelBuilder.Entity<StudentTest>(entity =>
        {
            entity.HasKey(e => e.Masv);

            entity.ToTable("students");

            entity.Property(e => e.Masv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("masv");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ghichu");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("gioitinh");
            entity.Property(e => e.Nganhhoc)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("nganhhoc");
            entity.Property(e => e.Ngaysinh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Quequan)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("quequan");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sodienthoai");
            entity.Property(e => e.Tensv)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("tensv");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
