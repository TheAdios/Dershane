using Dershane.Core.DTOs.KullaniciIslemleri;
using Dershane.Core.Models;
using Dershane.Core.Services;
using Dershane.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace W3CRM.Controllers
{
    public class MuhasebeController : BaseController
    {
        
        private readonly IService<DersUcret> _dersUcretService;
        private readonly IUnitOfWork _unitOfWork;

        public MuhasebeController(
       
            IUnitOfWork unitOfWork,
            IService<Kullanici> kullaniciService,
            IService<OgrenciDers> ogrenciDersService,
            IService<DersUcret> dersUcretService) : base(kullaniciService)
        {
            _unitOfWork = unitOfWork;
            _dersUcretService = dersUcretService;
        }
        public IActionResult MuhasebeIndex() 
        {

            ViewBag.Kullanici = KullaniciInfo.AdSoyad;
            string[] includes = { "Sinif", "Ders", "Ogretmen" };
            var kayit = _dersUcretService.GetList(x => x.Ogretmen.OgretmenTc == KullaniciInfo.PersonelNo, includes).ToList();
            return View(kayit);
        }

        public  IActionResult OdemeList()
        {
            string[] includes = { "Sinif", "Ders","Ogretmen" };
            var kayit = _dersUcretService.GetList(x=>true, includes).ToList();
            return View("OdemeList",kayit);
        }
    }
}
