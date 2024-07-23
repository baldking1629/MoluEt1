using Microsoft.AspNetCore.Mvc;
using MoluEt.Models;
using MoluEt.services;

namespace MoluEt.Controllers
{
    public class HayvanNeviController : Controller
    {
        HayvanNeviDataServices _HayvanNeviDataServices = new HayvanNeviDataServices();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HayvanNeviList(string searchTerm)
        {
            List<HayvanNevi> HayvanNeviGruplar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Eğer arama terimi boşsa, tüm listeyi getir.
                HayvanNeviGruplar = _HayvanNeviDataServices.GetList();
            }
            else
            {
                // Arama terimi varsa, arama yap.
                HayvanNeviGruplar = _HayvanNeviDataServices.HayvanNeviAra(searchTerm);
            }

            return View(HayvanNeviGruplar);
        }

        [HttpGet]
        public IActionResult HayvanNeviEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HayvanNeviEkle(HayvanNevi h)
        {
            _HayvanNeviDataServices.HayvanNeviEkle(h);
            return RedirectToAction("HayvanNeviList");
        }

        [HttpGet]
        public IActionResult HayvanNeviGuncelle(int id)
        {
            HayvanNevi h = _HayvanNeviDataServices.GetHayvanNeviById(id);
            return View(h);
        }

        [HttpPost]
        public IActionResult HayvanNeviGuncelle(HayvanNevi h, int id)
        {
            _HayvanNeviDataServices.HayvanNeviGuncelle(h, id);
            return RedirectToAction("HayvanNeviList");
        }

        [HttpPost]
        public IActionResult HayvanNeviSil(int id)
        {
            _HayvanNeviDataServices.HayvanNeviSil(id);
            return RedirectToAction("HayvanNeviList");
        }

    }
}
