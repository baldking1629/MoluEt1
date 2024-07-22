using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoluEt.Models;
using MoluEt.services;

namespace MoluEt.Controllers
{
    public class VeterinerController : Controller
    {

        VeterinerDataServices _veterinerDataServices = new VeterinerDataServices();
        IlIlceDataServices _ilIlceDataServices = new IlIlceDataServices();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VeterinerList()
        {
            List<Veteriner>? data = _veterinerDataServices.GetList();
            return View(data);

        }

        [HttpGet]
        public IActionResult VeterinerEkle()
        {
            List<Il> ilListe = _ilIlceDataServices.GetIlList();
            List<SelectListItem> IlList = (from i in ilListe
                                           select new SelectListItem
                                           {
                                               Text = i.ILAD,
                                               Value = i.ILNO.ToString(),


                                           }).ToList();
            ViewBag.il = IlList;
            return View();
        }

        [HttpPost]
        public IActionResult VeterinerEkle(Veteriner v)
        {
            _veterinerDataServices.VeterinerEkle(v);
            return RedirectToAction("VeterinerList");
        }

        [HttpGet]
        public IActionResult VeterinerGuncelle(int id)
        {
            Veteriner v = _veterinerDataServices.GetVeterinerById(id);
            List<Il> ilListe = _ilIlceDataServices.GetIlList();
            List<SelectListItem> IlList = (from i in ilListe
                                           select new SelectListItem
                                           {
                                               Text = i.ILAD,
                                               Value = i.ILNO.ToString(),


                                           }).ToList();

            ViewBag.il = IlList;
            List<Ilce> ilceListe = _ilIlceDataServices.GetIlceList(Convert.ToInt32(v.ADRES_IL));
            List<SelectListItem> IlceList = (from i in ilceListe
                                             select new SelectListItem
                                             {
                                                 Text = i.ILCEAD,
                                                 Value = i.ILCENO.ToString(),
                                                 Selected = true,


                                             }).ToList();

            ViewBag.ilce = IlceList;

            return View(v);
        }
        [HttpPost]
        public IActionResult VeterinerGuncelle(Veteriner v, int id)
        {
            _veterinerDataServices.VeterinerGuncelle(v, id);
            return RedirectToAction("VeterinerList");
        }
        [HttpGet]
        public IActionResult GetIlcelerByIlId(int ilId)
        {
            var ilceler = _ilIlceDataServices.GetIlceList(ilId).ToList();
            var ilceList = (from i in ilceler
                            select new SelectListItem
                            {
                                Text = i.ILCEAD,
                                Value = i.ILCENO.ToString(),
                            }).ToList();
            return Json(ilceList);
        }
    }
}
