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

        public IActionResult AsiList()
        {
            List<Asi> asilist = _asiDataServices.GetList();
            return View(asilist);
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
    }
}