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

        public IActionResult HayvanNeviList()
        {
            List<HayvanNevi> hayvanlistesi = _HayvanNeviDataServices.GetList();
            return View(hayvanlistesi);
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
