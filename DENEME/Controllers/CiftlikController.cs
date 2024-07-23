using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoluEt.Models;
using MoluEt.services;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;


namespace MoluEt.Controllers
{
    public class CiftlikController : Controller
    {
        CiftlikDataService _ciftlikDataService = new CiftlikDataService();
        IlIlceDataServices _ilIlceDataService = new IlIlceDataServices();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CiftlikList(string searchTerm)
        {
            List<Ciftlik> CiftlikGruplar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Eğer arama terimi boşsa, tüm listeyi getir.
                CiftlikGruplar = _ciftlikDataService.GetList();
            }
            else
            {
                // Arama terimi varsa, arama yap.
                CiftlikGruplar = _ciftlikDataService.CiftlikAra(searchTerm);
            }

            return View(CiftlikGruplar);
        }
        [HttpGet]
        public IActionResult CiftlikEkle()
        {


            List<Il> ilListe = _ilIlceDataService.GetIlList();
            List<SelectListItem> IlList = (from i in ilListe
                                           select new SelectListItem
                                           {
                                               Text = i.ILAD,
                                               Value = i.ILNO.ToString(),


                                           }).ToList();
            ViewBag.il = IlList;
            //List<Ilce> ilceListe = _ilIlceDataService.GetIlceList();
            //List<SelectListItem> IlceList = (from i in ilceListe
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = i.ILCEAD,
            //                                     Value = i.ILCENO.ToString(),


            //                                 }).ToList();
            //ViewBag.ilce = IlceList;
            return View();
        }


        [HttpPost]
        public IActionResult CiftlikEkle(Ciftlik c)
        {

            _ciftlikDataService.CiftlikEkle(c);
            return RedirectToAction("CiftlikList");

        }

        [HttpGet]

        public IActionResult CiftlikGuncelle(int id)
        {
            Ciftlik c = _ciftlikDataService.GetListForId(id);
            List<Il> ilListe = _ilIlceDataService.GetIlList();
            List<SelectListItem> IlList = (from i in ilListe
                                           select new SelectListItem
                                           {
                                               Text = i.ILAD,
                                               Value = i.ILNO.ToString(),


                                           }).ToList();

            ViewBag.il = IlList;
            List<Ilce> ilceListe = _ilIlceDataService.GetIlceList(Convert.ToInt32(c.IL));
            List<SelectListItem> IlceList = (from i in ilceListe
                                             select new SelectListItem
                                             {
                                                 Text = i.ILCEAD,
                                                 Value = i.ILCENO.ToString(),
                                                 Selected = true,


                                             }).ToList();

            ViewBag.ilce = IlceList;



            return View(c);
        }

        [HttpPost]
        public IActionResult CiftlikGuncelle(Ciftlik c, int id)
        {
            _ciftlikDataService.CiftlikGuncelleme(c, id);
            return RedirectToAction("CiftlikList");
        }

        [HttpGet]
        public IActionResult GetIlcelerByIlId(int ilId)
        {
            var ilceler = _ilIlceDataService.GetIlceList(ilId).ToList();
            var ilceList = (from i in ilceler
                            select new SelectListItem
                            {
                                Text = i.ILCEAD,
                                Value = i.ILCENO.ToString(),
                            }).ToList();
            return Json(ilceList);
        }

        [HttpPost]
        public IActionResult CiftlikSil(int id)
        {
            _ciftlikDataService.CiftlikSil(id);
            return RedirectToAction("CiftlikList");
        }


    }
}