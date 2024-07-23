using Microsoft.AspNetCore.Mvc;
using MoluEt.Models;
using MoluEt.services;

namespace MoluEt.Controllers
{
    public class YemlemeOgunController : Controller
    {
        YemlemeOgunDataServices _yemlemeOgunDataServices = new YemlemeOgunDataServices();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult YemlemeOgunList(string searchTerm)
        {
            List<YemlemeOgun> YemlemeOgunGruplar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Eğer arama terimi boşsa, tüm listeyi getir.
                YemlemeOgunGruplar = _yemlemeOgunDataServices.GetList();
            }
            else
            {
                // Arama terimi varsa, arama yap.
                YemlemeOgunGruplar = _yemlemeOgunDataServices.YemlemeOgunAra(searchTerm);
            }

            return View(YemlemeOgunGruplar);
        }

        [HttpGet]
        public IActionResult YemlemeOgunEkle()
        {

            return View();

        }

        [HttpPost]
        public IActionResult YemlemeOgunEkle(YemlemeOgun y)
        {
            _yemlemeOgunDataServices.YemlemeOgunEkleme(y); 
            return RedirectToAction("YemlemeOgunList");
        }

        [HttpGet]
        public IActionResult OgunGuncelle(int id)
        {
            YemlemeOgun y = _yemlemeOgunDataServices.GetYemlemeOgunForId(id);
            return View(y);
        }

        [HttpPost]
        public IActionResult OgunGuncelle(YemlemeOgun y, int id)
        {
            _yemlemeOgunDataServices.YemlemeOgunGuncelle(y, id);
            return RedirectToAction("YemlemeOgunList");
        }
        [HttpPost]
        public IActionResult YemlemeOgunSil(int id)
        {
            _yemlemeOgunDataServices.YemlemeOgunSil(id);
            return RedirectToAction("YemlemeOgunList");
        }

    }
}
