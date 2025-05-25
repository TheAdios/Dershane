using Dershane.Core.DTOs;
using Dershane.Core.DTOs.KullaniciIslemleri;
using Dershane.Core.Models;
using Dershane.Core.Services;
using Dershane.Core.UnitOfWorks;
using Dershane.Service.Common;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace W3CRM.Controllers
{
    public class OgrenciController : BaseController
    {
        private readonly IService<Ogrenci> _ogrenciService;
        private readonly IService<Ogretmen> _ogretmenService;
        private readonly IService<OgrenciDers> _ogrenciDersService;
        private readonly IUnitOfWork _unitOfWork;

        public OgrenciController(
            IService<Ogretmen> ogretmenService,
            IService<Ogrenci> ogrenciService,
            IUnitOfWork unitOfWork,
            IService<Kullanici> kullaniciService,
            IService<OgrenciDers> ogrenciDersService) : base(kullaniciService)
        {
            _ogretmenService = ogretmenService;
            _ogrenciService = ogrenciService;
            _unitOfWork = unitOfWork;
            _ogrenciDersService = ogrenciDersService;
        }

        [HttpPost]
        public async Task<IActionResult> DersKayit(int ogrenciDersId, DersKayitDto model)
        {

            //var ogretmen = await _ogretmenService.FirstOrDefaultAsync(o => o.OgretmenTc == KullaniciInfo.KullaniciId);
            //ViewBag.OgretmenId = ogretmen.OgretmenId;

            var kayitVarmi = ogrenciDersId > 0;
            if (kayitVarmi)
            {
                return Json(new JsonResultModel
                {
                    Basarili = true,
                    Mesaj = kayitVarmi ? ResponseMesaj.GUNCELLENDI : ResponseMesaj.EKLENDI,
                });
            }
            else
            {
                var yeniKayit = new OgrenciDers

                {
                    OgrenciId = model.OgrenciId,
                    OgretmenId = model.OgretmenId,
                    SinifId = model.SinifId,
                    BaslangicTarihi = model.BaslangicTarihi,
                    BitisTarihi = model.BitisTarihi,
                    GirilecekDersSaati = model.GirilecekDersSaati,
                    //BitisSaati = model.BitisSaati,
                    Aktif = true,
                    OgrenciIptali = false,
                    OgretmenNotu = model.OgretmenNotu,
                    OlusturmaTarihi = DateTime.Now,
                };
                await _ogrenciDersService.AddAsync(yeniKayit);
                await _unitOfWork.CommitAsync();
                return Json(new JsonResultModel { Basarili = true, Mesaj = ResponseMesaj.EKLENDI });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ogrenciList(int ogrenciId)
        {
            if (ogrenciId > 0)
            {
                var guncellenecekKayit =  await _ogrenciService.FirstOrDefaultAsync(x => x.OgrenciId == ogrenciId);
                return Json(new JsonResultModel { Basarili=true , NewObject = guncellenecekKayit });
            }
            else
            {
                var ogrenciList = _ogrenciService.GetList(x => x.Aktif == true).ToList();
                var ogrenciAdet = _ogrenciService.GetList(x => x.Aktif == true).Count();
                var ogretmenAdet = _ogretmenService.GetList(x => true).Count();

                ViewBag.OgrenciSayi = ogrenciAdet;
                ViewBag.OgretmenSayi = ogretmenAdet;
               
                return View("OgrenciList", ogrenciList);
            }
        }


        [HttpPost]
        public async Task<IActionResult> OgrenciKayit([FromBody] OgrenciKayitDto model)
        {
            if (model == null)
            {
                return Json(new JsonResultModel { Basarili=false , Mesaj="Lütfen tüm bilgileri eksiksiz girin ! "});
            }

            var yeni = new Ogrenci()
            {
                OgrenciAdi = model.OgrenciAdi,
                OgrenciSoyadi = model.OgrenciSoyadi,
                OgrenciTc = model.OgrenciTc,
                OgrenciTel = model.OgrenciTel,
                Aktif = true
            };

            await _ogrenciService.AddAsync(yeni);
            await _unitOfWork.CommitAsync();

            return Json(new JsonResultModel { Basarili = true, Mesaj = "Kayıt işlemi başarılı" });
        }

        public async Task<IActionResult> OgrenciSil (int ogrenciId)
        {
            var kayit = await _ogrenciService.FirstOrDefaultAsync(x => x.OgrenciId == ogrenciId);
            if(kayit != null)
            {
                kayit.Aktif = false;
                await _ogrenciService.UpdateAsync(kayit);
                await _unitOfWork.CommitAsync();
                return Json(new JsonResultModel { Basarili = true, Mesaj = ResponseMesaj.SILINDI });
            }
            else
            {
                return Json(new JsonResultModel { Basarili = false, Mesaj = "Kayıt Bulunamadı." });
            }
        }
        public async Task<IActionResult> OgrenciGuncelle (int ogrenciId , [FromBody] OgrenciKayitDto model)
        {
            var kayit = await _ogrenciService.FirstOrDefaultAsync(x => x.OgrenciId == ogrenciId);

             if (kayit != null)
             {
                kayit = model.Adapt(kayit);
                await _ogrenciService.UpdateAsync(kayit);
                await _unitOfWork.CommitAsync();
                return Json(new JsonResultModel
                {
                    Basarili = true,
                    Mesaj = ResponseMesaj.GUNCELLENDI,
                });
            }
            return Json(new JsonResultModel { Basarili = false, Mesaj = ResponseMesaj.BASARISIZ });
        }
    }
}
