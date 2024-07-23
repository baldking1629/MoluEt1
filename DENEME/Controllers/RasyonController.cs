using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoluEt.Models;
using MoluEt.services;
using System.Reflection.Metadata;

namespace MoluEt.Controllers
{

    public class RasyonController : Controller
    {
        RasyonDataServices _rasyonDataServices = new RasyonDataServices();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RasyonList()
        {
            List<Rasyon>? data = _rasyonDataServices.GetList();
            return View(data);

        }

        public IActionResult RasyonDetayList(int id)
        {
            List<Urun> emtiaListe = _rasyonDataServices.EmtiaGetir();
            List<SelectListItem> emtiaList = (from i in emtiaListe
                                              select new SelectListItem
                                              {
                                                  Text = i.EMTIAAD,
                                                  Value = i.EMTIANO.ToString(),


                                              }).ToList();
            ViewBag.emtia = emtiaList;
            int urunno = Convert.ToInt32(id.ToString().Substring(0, 6));
            int ciftlikno = Convert.ToInt32(id.ToString().Substring(6));
            List<RasyonDetay> data = _rasyonDataServices.GetListRasyonDetayById(urunno, ciftlikno);
            if (data.Count == 0)
            {
                return RedirectToAction("RasyonBosDetayEkle", new { id });
            }
            else
            {
                return View(data);
            }

        }
        [HttpGet]

        public IActionResult RasyonEkle()
        {
            List<Ciftlik> ciftlikListe = _rasyonDataServices.CiftlikGetir();
            List<SelectListItem> ciftlikList = (from i in ciftlikListe
                                                select new SelectListItem
                                                {
                                                    Text = i.CIFTLIKADI,
                                                    Value = i.CIFTLIKNO.ToString(),


                                                }).ToList();
            ViewBag.ciftlik = ciftlikList;
            List<Urun> urunListe = _rasyonDataServices.UrunGetir();
            List<SelectListItem> UrunList = (from i in urunListe
                                             select new SelectListItem
                                             {
                                                 Text = i.EMTIAAD,
                                                 Value = i.EMTIANO.ToString(),


                                             }).ToList();
            ViewBag.urun = UrunList;
            List<Urun> emtiaListe = _rasyonDataServices.EmtiaGetir();
            List<SelectListItem> emtiaList = (from i in emtiaListe
                                              select new SelectListItem
                                              {
                                                  Text = i.EMTIAAD,
                                                  Value = i.EMTIANO.ToString(),


                                              }).ToList();
            ViewBag.emtia = emtiaList;
            return View();
        }


        [HttpPost]

        public IActionResult RasyonEkle(Rasyon r)
        {

            _rasyonDataServices.RasyonEkle(r);

            return RedirectToAction("RasyonList");
        }

        [HttpGet]
        public IActionResult RasyonBosDetayEkle(int id)
        {
            List<Ciftlik> ciftlikListe = _rasyonDataServices.CiftlikGetir();
            List<SelectListItem> ciftlikList = (from i in ciftlikListe
                                                select new SelectListItem
                                                {
                                                    Text = i.CIFTLIKADI,
                                                    Value = i.CIFTLIKNO.ToString(),


                                                }).ToList();
            ViewBag.ciftlik = ciftlikList;
            List<Urun> urunListe = _rasyonDataServices.UrunGetir();
            List<SelectListItem> UrunList = (from i in urunListe
                                             select new SelectListItem
                                             {
                                                 Text = i.EMTIAAD,
                                                 Value = i.EMTIANO.ToString(),


                                             }).ToList();
            ViewBag.urun = UrunList;
            List<Urun> emtiaListe = _rasyonDataServices.EmtiaGetir();
            List<SelectListItem> emtiaList = (from i in emtiaListe
                                              select new SelectListItem
                                              {
                                                  Text = i.EMTIAAD,
                                                  Value = i.EMTIANO.ToString(),


                                              }).ToList();
            ViewBag.emtia = emtiaList;
            int urunno = Convert.ToInt32(id.ToString().Substring(0, 6));
            int ciftlikno = Convert.ToInt32(id.ToString().Substring(6));
            List<Rasyon> data = _rasyonDataServices.GetRasyonById(urunno, ciftlikno);
            return View(data);
        }

        [HttpPost]
        public IActionResult RasyonBosDetayEkle(RasyonDetay rd)
        {
            _rasyonDataServices.RasyonDetayEkle(rd);
            string no = "" + rd.URUNNO + rd.CIFTLIKNO;
            return RedirectToAction("RasyonDetayList", new { id = no });
        }


        public IActionResult RasyonDetayEkle(RasyonDetay rd)
        {
            _rasyonDataServices.RasyonDetayEkle(rd);
            string no = "" + rd.URUNNO + rd.CIFTLIKNO;
            return RedirectToAction("RasyonDetayList", new { id = no });
        }

        public IActionResult RasyonDetaySil(int ciftlikno,int urunno,int sirano)
        {
            _rasyonDataServices.RasyonDetaySil(ciftlikno, urunno, sirano);
            return RedirectToAction("RasyonDetayList", new {id = "" + urunno + ciftlikno} );
        }
    }
}
