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

        public IActionResult YemlemeOgunList()
        {
            List<YemlemeOgun> yemlemelist = _yemlemeOgunDataServices.GetList();
            return View(yemlemelist);
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
