using System;
using System.Collections.Generic;
using Dershane.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dershane.Core.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brans> Brans { get; set; }

    public virtual DbSet<Ders> Ders { get; set; }

    public virtual DbSet<DersSaat> DersSaat { get; set; }

    public virtual DbSet<DersUcret> DersUcret { get; set; }

    public virtual DbSet<Kullanici> Kullanici { get; set; }

    public virtual DbSet<KullaniciRol> KullaniciRol { get; set; }

    public virtual DbSet<MuhasebeKayitlari> MuhasebeKayitlari { get; set; }

    public virtual DbSet<Odeme> Odeme { get; set; }

    public virtual DbSet<Ogrenci> Ogrenci { get; set; }

    public virtual DbSet<OgrenciDers> OgrenciDers { get; set; }

    public virtual DbSet<Ogretmen> Ogretmen { get; set; }

    public virtual DbSet<OgretmenDersSaatleri> OgretmenDersSaatleri { get; set; }

    public virtual DbSet<OgretmenSinif> OgretmenSinif { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Sinif> Sinif { get; set; }

    public virtual DbSet<Takvim> Takvim { get; set; }

    public virtual DbSet<Veli> Veli { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Dershane;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brans>(entity =>
        {
            entity.HasKey(e => e.BransId).HasName("PK__Brans__D0E572ECFBFEE107");

            entity.Property(e => e.BransAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Ders>(entity =>
        {
            entity.HasKey(e => e.DersId).HasName("PK__Ders__E8B3DE1188AED3FF");

            entity.Property(e => e.DersAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<DersSaat>(entity =>
        {
            entity.HasKey(e => e.DersSaatId).HasName("PK__DersSaat__C006BE39AEC44B16");

            entity.Property(e => e.GirilenSaat).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Ogretmen).WithMany(p => p.DersSaat)
                .HasForeignKey(d => d.OgretmenId)
                .HasConstraintName("FK__DersSaat__Ogretm__571DF1D5");
        });

        modelBuilder.Entity<DersUcret>(entity =>
        {
            entity.HasKey(e => e.DersUcretId).HasName("PK__DersUcre__5A0EA069057A8248");

            entity.Property(e => e.OlusturmaTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SaatlikUcret).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Ders).WithMany(p => p.DersUcretNavigation)
                .HasForeignKey(d => d.DersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DersUcret_Ders");

            entity.HasOne(d => d.Ogretmen).WithMany(p => p.DersUcret)
                .HasForeignKey(d => d.OgretmenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DersUcret_Ogretmen");

            entity.HasOne(d => d.Sinif).WithMany(p => p.DersUcret)
                .HasForeignKey(d => d.SinifId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DersUcret_Sinif");
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.HasKey(e => e.KullaniciId).HasName("PK__Kullanic__E011F77B192904DC");

            entity.Property(e => e.KullaniciId).ValueGeneratedNever();
            entity.Property(e => e.AdSoyad).HasMaxLength(500);
            entity.Property(e => e.Brans).HasMaxLength(500);
            entity.Property(e => e.CepTel)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.EPosta).HasMaxLength(250);
            entity.Property(e => e.Parola).IsUnicode(false);
            entity.Property(e => e.PersonelNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<KullaniciRol>(entity =>
        {
            entity.HasKey(e => e.KullaniciRolId).HasName("PK__Kullanic__F316ADA92FA37CC6");

            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
        });

        modelBuilder.Entity<MuhasebeKayitlari>(entity =>
        {
            entity.HasKey(e => e.KayitId).HasName("PK__Muhasebe__BD28AF4BC6DA0638");

            entity.Property(e => e.HesaplananTarih)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ToplamSaat).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ToplamTutar).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Ogretmen).WithMany(p => p.MuhasebeKayitlari)
                .HasForeignKey(d => d.OgretmenId)
                .HasConstraintName("FK__MuhasebeK__Ogret__656C112C");
        });

        modelBuilder.Entity<Odeme>(entity =>
        {
            entity.HasKey(e => e.OdemeId).HasName("PK__Odeme__B11B668D758C8599");

            entity.Property(e => e.OdemeTuru).HasMaxLength(50);
        });

        modelBuilder.Entity<Ogrenci>(entity =>
        {
            entity.HasKey(e => e.OgrenciId).HasName("PK__Ogrenci__E497E6B4D27CC5EA");

            entity.Property(e => e.OgrenciAdi).HasMaxLength(50);
            entity.Property(e => e.OgrenciSoyadi).HasMaxLength(50);
            entity.Property(e => e.OgrenciTc).HasMaxLength(50);
            entity.Property(e => e.OgrenciTel).HasMaxLength(20);
        });

        modelBuilder.Entity<OgrenciDers>(entity =>
        {
            entity.HasKey(e => e.OgrenciDersId).HasName("PK__OgrenciD__C6ECD76C8B2EECB7");

            entity.Property(e => e.OgretmenNotu).HasMaxLength(500);
            entity.Property(e => e.OlusturmaTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Ogrenci).WithMany(p => p.OgrenciDers)
                .HasForeignKey(d => d.OgrenciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OgrenciDers_Ogrenci");

            entity.HasOne(d => d.Ogretmen).WithMany(p => p.OgrenciDers)
                .HasForeignKey(d => d.OgretmenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OgrenciDers_Ogretmen");

            entity.HasOne(d => d.Sinif).WithMany(p => p.OgrenciDers)
                .HasForeignKey(d => d.SinifId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OgrenciDers_Sinif");
        });

        modelBuilder.Entity<Ogretmen>(entity =>
        {
            entity.HasKey(e => e.OgretmenId).HasName("PK__Ogretmen__27A3276F2C84493D");

            entity.Property(e => e.OgretmenAdi).HasMaxLength(50);
            entity.Property(e => e.OgretmenMail).HasMaxLength(100);
            entity.Property(e => e.OgretmenSoyadi).HasMaxLength(50);
            entity.Property(e => e.OgretmenTc)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OgretmenDersSaatleri>(entity =>
        {
            entity.HasKey(e => e.KayitId).HasName("PK__Ogretmen__BD28AF4B7F7DE2B6");

            entity.Property(e => e.SaatlikUcret).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ToplamSaat).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ToplamTutar)
                .HasComputedColumnSql("(CONVERT([decimal](10,2),[ToplamSaat])*CONVERT([decimal](10,2),[SaatlikUcret]))", true)
                .HasColumnType("decimal(21, 4)");

            entity.HasOne(d => d.Ders).WithMany(p => p.OgretmenDersSaatleri)
                .HasForeignKey(d => d.DersId)
                .HasConstraintName("FK__OgretmenD__DersI__628FA481");

            entity.HasOne(d => d.Ogretmen).WithMany(p => p.OgretmenDersSaatleri)
                .HasForeignKey(d => d.OgretmenId)
                .HasConstraintName("FK__OgretmenD__Ogret__60A75C0F");

            entity.HasOne(d => d.Sinif).WithMany(p => p.OgretmenDersSaatleri)
                .HasForeignKey(d => d.SinifId)
                .HasConstraintName("FK__OgretmenD__Sinif__619B8048");
        });

        modelBuilder.Entity<OgretmenSinif>(entity =>
        {
            entity.HasKey(e => e.OgretmenSinifId).HasName("PK__Ogretmen__29763B127EEEEEB8");

            entity.Property(e => e.Ucret).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__F92302F1ACA95878");

            entity.Property(e => e.RolId).ValueGeneratedNever();
            entity.Property(e => e.Aciklama)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Tanim)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sinif>(entity =>
        {
            entity.HasKey(e => e.SinifId).HasName("PK__Sinif__5D59A88BDC0BA52C");

            entity.Property(e => e.SinifSeviyesi).HasMaxLength(50);
        });

        modelBuilder.Entity<Takvim>(entity =>
        {
            entity.HasKey(e => e.TakvimId).HasName("PK__Takvim__A2EB925695374EE8");
        });

        modelBuilder.Entity<Veli>(entity =>
        {
            entity.HasKey(e => e.VeliId).HasName("PK__Veli__21C446257CF85D59");

            entity.Property(e => e.VeliAdi).HasMaxLength(50);
            entity.Property(e => e.VeliMail).HasMaxLength(100);
            entity.Property(e => e.VeliSoyadi).HasMaxLength(50);
            entity.Property(e => e.VeliTc).HasMaxLength(11);
            entity.Property(e => e.VeliTel).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
