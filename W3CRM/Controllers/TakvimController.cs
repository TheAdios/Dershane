using Dershane.Core.DTOs.KullaniciIslemleri;
using Dershane.Core.Models;
using Dershane.Core.Services;
using Dershane.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace W3CRM.Controllers
{
    public class TakvimController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService<Ogretmen> _ogretmenService;
        private readonly IService<OgrenciDers> _ogrenciDersService;
        private readonly IService<Ogrenci> _ogrenciService;
        private readonly IUnitOfWork _unitOfWork;

        public TakvimController(IService<Kullanici> kullaniciService, IService<Ogretmen> ogretmenService, IService<OgrenciDers> ogrenciDersService, IUnitOfWork unitOfWork, IService<Ogrenci> ogrenciService) : base(kullaniciService)
        {
            _ogretmenService = ogretmenService;
            _ogrenciDersService = ogrenciDersService;
            _unitOfWork = unitOfWork;
            _ogrenciService = ogrenciService;
        }
        public IActionResult GunDersList(DateOnly tarih)
        {
            var model = KullaniciInfo;
            var ogretmenkayit = _ogretmenService.GetList(x => x.OgretmenTc == model.PersonelNo);
            var ogretmenId = ogretmenkayit.FirstOrDefault().OgretmenId;
            var kayit = _ogrenciDersService.GetList(x => x.BaslangicTarihi == tarih);

            var sonuc = kayit.Select(x => new
            {
                OgrenciAdi = x.Ogrenci.OgrenciAdi + "" + x.Ogrenci.OgrenciSoyadi,
                GirilecekDersSaati = x.GirilecekDersSaati.ToString("HH.mm"),
                //BitisSaati = x.BitisSaati.ToString("HH.mm"),
                Seviye = x.Sinif.SinifSeviyesi,
                Durum = x.Aktif ? "Aktif" : "İptal",
                OlusturmaTarihi = x.OlusturmaTarihi.HasValue ? x.OlusturmaTarihi.Value.ToString("dd.MM.yyyy") : "-"
            }).ToList();
            return Json(sonuc);
        }
    }
}
