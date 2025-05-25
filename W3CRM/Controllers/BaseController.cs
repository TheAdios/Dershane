using Dershane.Core.Models;
using Dershane.Core.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Dershane.Core.DTOs.KullaniciIslemleri;

namespace W3CRM.Controllers
{
    public class BaseController : Controller
    {
        public readonly IService<Kullanici> _kullaniciService;
        public BaseController(IService<Kullanici> kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }
        public KullaniciClaimsDto KullaniciInfo
        {
            get
            {
                //ClaimsPrincipal principal = this.User;

                var id = User.FindFirst(x => x.Type.Contains("nameidentifier")).Value;
                var adSoyad = User.FindFirst(x => x.Type.Contains("name") && !x.Type.Contains("nameidentifier")).Value;
                var brans = User.FindFirst(x => x.Type.Contains("Brans")).Value;
                var personelNo = User.FindFirst(x => x.Type == "PersonelNo").Value;
                var mail = User.FindFirst(x => x.Type.Contains("emailaddress")).Value;
                var kullanici = new KullaniciClaimsDto { AdSoyad = adSoyad, KullaniciId = Guid.Parse(id), PersonelNo = personelNo , Brans= brans , EPosta= mail };
                return kullanici;
            }
        }
        //public List<string> KullaniciRolList
        //{
        //    get
        //    {
        //        if (!User.Identity.IsAuthenticated)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            ClaimsPrincipal principal = this.User;
        //            var rolList = principal.Claims.Where(x => x.Type.Contains("role")).Select(x => x.Value).ToList();
        //            return rolList;
        //        }
        //    }
        //}
    }
}
