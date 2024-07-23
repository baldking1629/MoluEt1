using DENEME.Models;
using Microsoft.AspNetCore.Mvc;
using MoluEt.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace MoluEt.Controllers
{
    public class IrkTanımController : Controller
    {
        IrKTanımServices _IrKTanımServices = new IrKTanımServices();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Irklistesi(string searchTerm)
        {
            
            List<IrkTanım> IrkGruplar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Eğer arama terimi boşsa, tüm listeyi getir.
                IrkGruplar = _IrKTanımServices.GetList();
            }
            else
            {
                // Arama terimi varsa, arama yap.
                IrkGruplar = _IrKTanımServices.IrkAra(searchTerm);
            }

            return View(IrkGruplar);
        }
        [HttpGet]
        public IActionResult IrkTanımEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IrkTanımEkle(IrkTanım h)
        {
            _IrKTanımServices.IrkEkle(h);
            return RedirectToAction("IrkListesi");
        }

        [HttpGet]
        public IActionResult IrkTanımGuncelle(int id)
        {
            IrkTanım h = _IrKTanımServices.GetIrkTanımById(id);
            return View(h);
        }

        [HttpPost]
        public IActionResult IrkTanımGuncelle(IrkTanım h, int id)
        {
            _IrKTanımServices.IrkGuncelle(h, id);
            return RedirectToAction("IrkListesi");
        }


        [HttpPost]
        public IActionResult IrkTanımSil(int id) 
        {
            _IrKTanımServices.IrkSil(id);
            return RedirectToAction("Irklistesi");
        }


        [HttpGet]
        public IActionResult IrkListesi(string searchTerm)
        {
            List<IrkTanım> IrkTanımlistesi;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                IrkTanımlistesi = _IrKTanımServices.GetList();
            }
            else
            {
                IrkTanımlistesi = _IrKTanımServices.IrkAra(searchTerm);
            }

            return View(IrkTanımlistesi);
        }


    }
}
