using Dershane.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace W3CRM.Controllers
{
    public class TalepController : Controller
    {
        public IActionResult TalepFormIndex()
        {
            return View();
        }   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Talep talep)
        {
            if (ModelState.IsValid)
            {
                talep.TalepTarihi = DateTime.Now;
                TempData["Mesaj"] = "Talebiniz başarıyla alındı.";
                return RedirectToAction("TalepFormIndex");
            }
            return View("TalepFormIndex", talep);
        }
    }
}
