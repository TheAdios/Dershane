using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dershane.Core.Migrations
{
    /// <inheritdoc />
    public partial class Dershane1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brans",
                columns: table => new
                {
                    BransId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BransAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Brans__D0E572ECFBFEE107", x => x.BransId);
                });

            migrationBuilder.CreateTable(
                name: "Ders",
                columns: table => new
                {
                    DersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DersUcret = table.Column<int>(type: "int", nullable: false),
                    OgretmenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ders__E8B3DE1188AED3FF", x => x.DersId);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonelNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Brans = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CepTel = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    EPosta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Parola = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kullanic__E011F77B192904DC", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRol",
                columns: table => new
                {
                    KullaniciRolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    KayitKullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kullanic__F316ADA92FA37CC6", x => x.KullaniciRolId);
                });

            migrationBuilder.CreateTable(
                name: "Odeme",
                columns: table => new
                {
                    OdemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    Oran = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateOnly>(type: "date", nullable: false),
                    OdemeTuru = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Odeme__B11B668D758C8599", x => x.OdemeId);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenci",
                columns: table => new
                {
                    OgrenciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OgrenciSoyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OgrenciTel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OgrenciTc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VeliId = table.Column<int>(type: "int", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ogrenci__E497E6B4D27CC5EA", x => x.OgrenciId);
                });

            migrationBuilder.CreateTable(
                name: "Ogretmen",
                columns: table => new
                {
                    OgretmenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OgretmenSoyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OgretmenMail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OgretmenTc = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    OgretmenDuzey = table.Column<int>(type: "int", nullable: false),
                    BransId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ogretmen__27A3276F2C84493D", x => x.OgretmenId);
                });

            migrationBuilder.CreateTable(
                name: "OgretmenSinif",
                columns: table => new
                {
                    OgretmenSinifId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenId = table.Column<int>(type: "int", nullable: false),
                    SinifId = table.Column<int>(type: "int", nullable: false),
                    Ucret = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ogretmen__29763B127EEEEEB8", x => x.OgretmenSinifId);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolNo = table.Column<int>(type: "int", nullable: false),
                    Tanim = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__F92302F1ACA95878", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Sinif",
                columns: table => new
                {
                    SinifId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifSeviyesi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sinif__5D59A88BDC0BA52C", x => x.SinifId);
                });

            migrationBuilder.CreateTable(
                name: "Takvim",
                columns: table => new
                {
                    TakvimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenId = table.Column<int>(type: "int", nullable: false),
                    DersSaatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Takvim__A2EB925695374EE8", x => x.TakvimId);
                });

            migrationBuilder.CreateTable(
                name: "Veli",
                columns: table => new
                {
                    VeliId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeliAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VeliSoyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VeliTc = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    VeliTel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VeliMail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Veli__21C446257CF85D59", x => x.VeliId);
                });

            migrationBuilder.CreateTable(
                name: "DersSaat",
                columns: table => new
                {
                    DersSaatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenId = table.Column<int>(type: "int", nullable: false),
                    DersTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    GirilenSaat = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DersSaat__C006BE39AEC44B16", x => x.DersSaatId);
                    table.ForeignKey(
                        name: "FK__DersSaat__Ogretm__571DF1D5",
                        column: x => x.OgretmenId,
                        principalTable: "Ogretmen",
                        principalColumn: "OgretmenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MuhasebeKayitlari",
                columns: table => new
                {
                    KayitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenId = table.Column<int>(type: "int", nullable: true),
                    DonemAy = table.Column<int>(type: "int", nullable: false),
                    DonemYil = table.Column<int>(type: "int", nullable: false),
                    ToplamSaat = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    HesaplananTarih = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Muhasebe__BD28AF4BC6DA0638", x => x.KayitId);
                    table.ForeignKey(
                        name: "FK__MuhasebeK__Ogret__656C112C",
                        column: x => x.OgretmenId,
                        principalTable: "Ogretmen",
                        principalColumn: "OgretmenId");
                });

            migrationBuilder.CreateTable(
                name: "DersUcret",
                columns: table => new
                {
                    DersUcretId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenId = table.Column<int>(type: "int", nullable: false),
                    SinifId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false),
                    SaatlikUcret = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DersUcre__5A0EA069057A8248", x => x.DersUcretId);
                    table.ForeignKey(
                        name: "FK_DersUcret_Ders",
                        column: x => x.DersId,
                        principalTable: "Ders",
                        principalColumn: "DersId");
                    table.ForeignKey(
                        name: "FK_DersUcret_Ogretmen",
                        column: x => x.OgretmenId,
                        principalTable: "Ogretmen",
                        principalColumn: "OgretmenId");
                    table.ForeignKey(
                        name: "FK_DersUcret_Sinif",
                        column: x => x.SinifId,
                        principalTable: "Sinif",
                        principalColumn: "SinifId");
                });

            migrationBuilder.CreateTable(
                name: "OgrenciDers",
                columns: table => new
                {
                    OgrenciDersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenId = table.Column<int>(type: "int", nullable: false),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    SinifId = table.Column<int>(type: "int", nullable: false),
                    BaslangicTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    BitisTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    GirilecekDersSaati = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    OgrenciIptali = table.Column<bool>(type: "bit", nullable: false),
                    OgretmenNotu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OgrenciD__C6ECD76C8B2EECB7", x => x.OgrenciDersId);
                    table.ForeignKey(
                        name: "FK_OgrenciDers_Ogrenci",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrenci",
                        principalColumn: "OgrenciId");
                    table.ForeignKey(
                        name: "FK_OgrenciDers_Ogretmen",
                        column: x => x.OgretmenId,
                        principalTable: "Ogretmen",
                        principalColumn: "OgretmenId");
                    table.ForeignKey(
                        name: "FK_OgrenciDers_Sinif",
                        column: x => x.SinifId,
                        principalTable: "Sinif",
                        principalColumn: "SinifId");
                });

            migrationBuilder.CreateTable(
                name: "OgretmenDersSaatleri",
                columns: table => new
                {
                    KayitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenId = table.Column<int>(type: "int", nullable: true),
                    SinifId = table.Column<int>(type: "int", nullable: true),
                    DersId = table.Column<int>(type: "int", nullable: true),
                    DersTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    ToplamSaat = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    SaatlikUcret = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(21,4)", nullable: true, computedColumnSql: "(CONVERT([decimal](10,2),[ToplamSaat])*CONVERT([decimal](10,2),[SaatlikUcret]))", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ogretmen__BD28AF4B7F7DE2B6", x => x.KayitId);
                    table.ForeignKey(
                        name: "FK__OgretmenD__DersI__628FA481",
                        column: x => x.DersId,
                        principalTable: "Ders",
                        principalColumn: "DersId");
                    table.ForeignKey(
                        name: "FK__OgretmenD__Ogret__60A75C0F",
                        column: x => x.OgretmenId,
                        principalTable: "Ogretmen",
                        principalColumn: "OgretmenId");
                    table.ForeignKey(
                        name: "FK__OgretmenD__Sinif__619B8048",
                        column: x => x.SinifId,
                        principalTable: "Sinif",
                        principalColumn: "SinifId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DersSaat_OgretmenId",
                table: "DersSaat",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_DersUcret_DersId",
                table: "DersUcret",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_DersUcret_OgretmenId",
                table: "DersUcret",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_DersUcret_SinifId",
                table: "DersUcret",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_MuhasebeKayitlari_OgretmenId",
                table: "MuhasebeKayitlari",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDers_OgrenciId",
                table: "OgrenciDers",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDers_OgretmenId",
                table: "OgrenciDers",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDers_SinifId",
                table: "OgrenciDers",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_OgretmenDersSaatleri_DersId",
                table: "OgretmenDersSaatleri",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_OgretmenDersSaatleri_OgretmenId",
                table: "OgretmenDersSaatleri",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_OgretmenDersSaatleri_SinifId",
                table: "OgretmenDersSaatleri",
                column: "SinifId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brans");

            migrationBuilder.DropTable(
                name: "DersSaat");

            migrationBuilder.DropTable(
                name: "DersUcret");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "KullaniciRol");

            migrationBuilder.DropTable(
                name: "MuhasebeKayitlari");

            migrationBuilder.DropTable(
                name: "Odeme");

            migrationBuilder.DropTable(
                name: "OgrenciDers");

            migrationBuilder.DropTable(
                name: "OgretmenDersSaatleri");

            migrationBuilder.DropTable(
                name: "OgretmenSinif");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Takvim");

            migrationBuilder.DropTable(
                name: "Veli");

            migrationBuilder.DropTable(
                name: "Ogrenci");

            migrationBuilder.DropTable(
                name: "Ders");

            migrationBuilder.DropTable(
                name: "Ogretmen");

            migrationBuilder.DropTable(
                name: "Sinif");
        }
    }
}
