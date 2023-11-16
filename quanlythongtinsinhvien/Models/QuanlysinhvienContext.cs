using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace quanlythongtinsinhvien.Models;

public partial class QuanlysinhvienContext : DbContext
{
    public QuanlysinhvienContext()
    {
    }

    public QuanlysinhvienContext(DbContextOptions<QuanlysinhvienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NHICOMPUTER\\WNSEVER;Initial Catalog=quanlysinhvien;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Vietnamese_100_CI_AS_KS_WS_SC_UTF8");

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Masv).HasName("PK__students__7A21767CBEDF8312");

            entity.ToTable("students");

            entity.Property(e => e.Masv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("masv");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ghichu");
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
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gioitinh");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
