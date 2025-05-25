using Dershane.Core.Models;
using Dershane.Core.Services;
using Dershane.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using W3CRM.Models;

namespace W3CRM.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    private readonly IService<Ogretmen> _ogretmenService;
    private readonly IService<OgrenciDers> _ogrenciDersService;
    private readonly IService<Ogrenci> _ogrenciService;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(IService<Kullanici> kullaniciService, IService<Ogretmen> ogretmenService, IService<OgrenciDers> ogrenciDersService, IUnitOfWork unitOfWork, IService<Ogrenci> ogrenciService) : base(kullaniciService)
    {
        _ogretmenService = ogretmenService;
        _ogrenciDersService = ogrenciDersService;
        _unitOfWork = unitOfWork;
        _ogrenciService = ogrenciService;
    }

    //private readonly IService<Kullanici> _kullaniciService;

    //public HomeController(IService<Kullanici> kullaniciService)
    //{ 
    //    _kullaniciService = kullaniciService;

    //}

    //public HomeController(ILogger<HomeController> logger)
    //{
    //    _logger = logger;
    //}

    public async Task<IActionResult> Index()
    {
        // Kullanıcı bilgilerini ViewBag ile aktarma
        ViewBag.Brans = KullaniciInfo.Brans;
        ViewBag.Mail = KullaniciInfo.EPosta;
        ViewBag.KullanıcıAdSoyad = KullaniciInfo.AdSoyad;

        // Öğrenci listesini dropdown için hazırlama
        var ogrenciListesi = await _ogrenciService.GetAllAsync();
        var selectListItem = ogrenciListesi.Select(x => new SelectListItem
        {
            Value = x.OgrenciId.ToString(),
            Text = $"{x.OgrenciAdi} {x.OgrenciSoyadi}"
        }).ToList();

        SelectList selectList = new SelectList(selectListItem, "Value", "Text");
        ViewBag.OgrenciListesi = selectList;

        // Öğretmen bilgisini çekme
        var personelNo = User.FindFirst(x => x.Type == "PersonelNo").Value;
        var ogretmen = await _ogretmenService.FirstOrDefaultAsync(o => o.OgretmenTc == personelNo);
        ViewBag.OgretmenId = ogretmen.OgretmenId;

        // OgrenciDers tablosundaki verileri çekme
        string[] includes = { "Ogrenci", "Sinif" };
        var ogrenciDersListesi = _ogrenciDersService.GetList(x => true, includes);

        // Verileri view'a aktarma
        return View(ogrenciDersListesi);
    }

    //[HttpPost]
    //public async Task<IActionResult> DersKayit( int ogrenciDersId,DersKayitDto model)
    //{
    //    var kayitVarmi = ogrenciDersId > 0;
    //    if(kayitVarmi)
    //    {
    //        return Json(new JsonResultModel
    //        {
    //            Basarili = true,
    //            Mesaj = kayitVarmi ? ResponseMesaj.GUNCELLENDI : ResponseMesaj.EKLENDI,
    //        });
    //    }
    //    else
    //    {
    //        var yeniKayit = new OgrenciDers

    //        {
    //            OgrenciId = model.OgrenciId,
    //            OgretmenId = model.OgretmenId,
    //            SinifId = model.SinifId,
    //            BaslangicTarihi = model.BaslangicTarihi,
    //            BitisTarihi = model.BitisTarihi,
    //            BaslangicSaati = model.BaslangicSaati,
    //            BitisSaati = model.BitisSaati,
    //            Aktif = true,
    //            OgrenciIptali=false,
    //            OgretmenNotu=model.OgretmenNotu,
    //            OlusturmaTarihi=DateTime.Now,
    //        };
    //        await _ogrenciDersService.AddAsync(yeniKayit);
    //        await _unitOfWork.CommitAsync();
    //        return Json(new JsonResultModel {Basarili=true, Mesaj=ResponseMesaj.EKLENDI});
    //    }
    //}
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}