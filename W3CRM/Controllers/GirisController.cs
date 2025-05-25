using System.Security.Claims;
using Dershane.Core.Models;
using Dershane.Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using W3CRM.Models;

namespace W3CRM.Controllers
{
    public class GirisController : Controller
    {
        private readonly IService<Kullanici> _kullaniciService;

        public GirisController(IService<Kullanici> kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            // Kullanıcı adı ve şifre boşsa uyarı göster
            if (string.IsNullOrWhiteSpace(model.PersonelNo) || string.IsNullOrWhiteSpace(model.Parola))
            {
                ViewData["Uyarı"] = "Lütfen Personel No / Şifre giriniz.";
                return View("Login");
            }

            // İlgili kullanıcıyı veritabanından getir
            //string[] includes = { "KullaniciRol" /*"KullaniciRol.Rol"*/};
            
            var user = await _kullaniciService.FirstOrDefaultAsync(
                x =>
                (x.PersonelNo == model.PersonelNo || x.PersonelNo == model.PersonelNo.PadLeft(8, '0'))
                && x.Aktif
                
            );

            // Kullanıcı kontrolü
            if (user != null)
            {
                // Şifre doğrulama işlemi (şifreleme gibi kontroller gerekiyorsa burada yapılabilir)
                if (user.Parola != model.Parola) // Parola veritabanındakiyle eşleşmiyorsa
                {
                    ViewData["Hata"] = "Kullanıcı Adı / Şifreniz Uyuşmuyor.";
                    return View("Giris/Login");
                }

                try
                {
                    // Kullanıcı claim'lerini oluştur
                    List<Claim> userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.KullaniciId.ToString()),
                new Claim(ClaimTypes.Name, user.AdSoyad),
                new Claim(ClaimTypes.Email, user.EPosta),
                new Claim("Brans", user.Brans?.ToString() ?? "Branş Yok"),
                new Claim("KullaniciId", user.KullaniciId.ToString()),
                new Claim("PersonelNo", user.PersonelNo),
                
            };

                    // Kullanıcı rollerini claim'lere ekle
                    //foreach (var item in user.KullaniciRol.ToList())
                    //{
                    //    userClaims.Add(new Claim(ClaimTypes.Role, item.Rol.Tanim));
                    //}

                    // ClaimsIdentity oluştur
                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.BeniHatirla // "Beni Hatırla" seçeneği
                    };

                    // Kullanıcıyı sisteme giriş yaptır
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // Önce çıkış yap
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    // Session bilgilerini kaydet
                    HttpContext.Session.SetString("KullaniciId", user.KullaniciId.ToString());
                    HttpContext.Session.SetString("AdSoyad", user.AdSoyad);

                    return Json(new { success = true, message = "Giriş başarılı", redirectUrl = Url.Action("Index", "Home") });

                }
                catch (Exception ex)
                {
                    
                    ViewData["Hata"] = "Sistemde beklenmeyen bir hata oluştu.";
                    return View("Login");
                    
                }
            }
            else
            {
                // Kullanıcı bulunamazsa hata mesajı
                ViewData["Hata"] = "Kullanıcı Adı veya Şifreniz Yanlış.";
                return View("Login");
            }
        }

    }
}
