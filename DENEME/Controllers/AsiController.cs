using Microsoft.AspNetCore.Mvc;
using MoluEt.Models;
using MoluEt.services;

namespace MoluEt.Controllers
{
    public class AsiController : Controller
    {
        AsiDataServices _asiDataServices = new AsiDataServices();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AsiList(string searchTerm)
        {
            List<Asi> AsiGruplar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Eğer arama terimi boşsa, tüm listeyi getir.
                AsiGruplar = _asiDataServices.GetList();
            }
            else
            {
                // Arama terimi varsa, arama yap.
                AsiGruplar = _asiDataServices.AsiAra(searchTerm);
            }

            return View(AsiGruplar);
        }

        [HttpGet]
        public IActionResult AsiEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AsiEkle(Asi asi)
        {
            _asiDataServices.AsiEkle(asi);
            return RedirectToAction("AsiList");
        }

        [HttpGet]
        public IActionResult AsiGuncelle(int id)
        {
            Asi asi = _asiDataServices.GetAsiById(id);
            return View(asi);
        }

        [HttpPost]
        public IActionResult AsiGuncelle(Asi asi, int id)
        {
            _asiDataServices.AsiGuncelle(asi, id);
            return RedirectToAction("AsiList");
        }

        [HttpPost]
        public IActionResult AsiSil(int id)
        {
            _asiDataServices.AsiSil(id);
            return RedirectToAction("AsiList");
        }
    }
}