using DENEME.Models;
using Microsoft.AspNetCore.Mvc;
using MoluEt.Models;
using System.Collections.Generic;

namespace MoluEt.Controllers
{
    public class BesiGrupTanımController : Controller
    {
        private readonly BesiGrupTanımServices _besiGrupTanımServices;

        public BesiGrupTanımController()
        {
            _besiGrupTanımServices = new BesiGrupTanımServices();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult BesiGruplistesi(string searchTerm)
        {
            List<BesiGrup> besiGruplar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Eğer arama terimi boşsa, tüm listeyi getir.
                besiGruplar = _besiGrupTanımServices.GetList();
            }
            else
            {
                // Arama terimi varsa, arama yap.
                besiGruplar = _besiGrupTanımServices.BesiAra(searchTerm);
            }

            return View(besiGruplar);
        }

        [HttpGet]
        public IActionResult BesiGrupTanımEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BesiGrupTanımEkle(BesiGrup model)
        {


            _besiGrupTanımServices.BesiGrupEkle(model);
            return RedirectToAction("BesiGruplistesi");

        }


    

        [HttpGet]
        public IActionResult BesiGrupTanımGuncelle(int id)
        {
            BesiGrup h = _besiGrupTanımServices.GetBesiGrupById(id);
            return View(h);
        }

        [HttpPost]
        public IActionResult BesiGrupTanımGuncelle(BesiGrup model, int id)
        {
           
                _besiGrupTanımServices.BesiGrupGuncelle(model, id);
                return RedirectToAction("BesiGruplistesi");
           
        }

        public IActionResult BesiGrupTanımSil(int id)
        {
            _besiGrupTanımServices.BesiGrupSil(id);
            return RedirectToAction("BesiGruplistesi");
        }
    }
}
