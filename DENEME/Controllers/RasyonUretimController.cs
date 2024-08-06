using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MoluEt.Models;
using MoluEt.services;

namespace MoluEt.Controllers
{
    public class RasyonUretimController : Controller
    {
        RasyonUretimDataServices _rasyonUretimDataServices = new RasyonUretimDataServices();
        RasyonDataServices _rasyonDataServices = new RasyonDataServices();
        CiftlikDataService _ciftlikDataServices = new CiftlikDataService();

        public IActionResult RasyonUretimListele(string searchTerm)
        {
            List<RasyonUretim> RasyonUretimGruplar;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Eğer arama terimi boşsa, tüm listeyi getir.
                RasyonUretimGruplar = _rasyonUretimDataServices.GetList();
            }
            else
            {
                // Arama terimi varsa, arama yap.
                RasyonUretimGruplar = _rasyonUretimDataServices.RasyonUretimAra(searchTerm);
            }

            return View(RasyonUretimGruplar);
        }

        [HttpGet]
        public IActionResult RasyonUretimEkle()
        {
            List<Ciftlik> ciftlikListe = _ciftlikDataServices.GetList();
            List<SelectListItem> ciftlikList = (from i in ciftlikListe
                                                select new SelectListItem
                                                {
                                                    Text = i.CIFTLIKADI,
                                                    Value = i.CIFTLIKNO.ToString(),


                                                }).ToList();
            ViewBag.ciftlik = ciftlikList;
            return View();
        }

        [HttpPost]
        public IActionResult RasyonUretimEkle(RasyonUretim r)
        {
            r.SIRKETNO = Convert.ToInt32(User.Identity.Name);
            _rasyonUretimDataServices.RasyonUretimEkle(r);
            return RedirectToAction("RasyonUretimListele");
        }

        public IActionResult RasyonUretimDetayList(int uretimno, int ciftlikno)
        {
            List<Urun> emtiaListe = _rasyonDataServices.EmtiaGetir();
            List<SelectListItem> emtiaList = (from i in emtiaListe
                                              select new SelectListItem
                                              {
                                                  Text = i.EMTIAAD,
                                                  Value = i.EMTIANO.ToString(),


                                              }).ToList();
            ViewBag.emtia = emtiaList;
            List<RasyonUretimDetay> data = _rasyonUretimDataServices.GetRasyonUretimById(uretimno, ciftlikno);
            return View(data);
        }

        public IActionResult RasyonUretimDetayEkle(RasyonUretimDetay r)
        {
            r.SIRKETNO = Convert.ToInt32(User.Identity.Name);
            _rasyonUretimDataServices.RasyonUretimDetayEkle(r);
            return RedirectToAction("RasyonUretimDetayList", new { uretimno = r.URETIMNO, ciftlikno = r.CIFTLIKNO });
        }

        public IActionResult RasyonUretimGuncelle(RasyonUretim r)
        {
            _rasyonUretimDataServices.RasyonUretimGuncelle(r);
            return RedirectToAction("RasyonUretimDetayList", new { uretimno = r.URETIMNO, ciftlikno = r.CIFTLIKNO });
        }
        public IActionResult RasyonUretimDetayGuncelle(RasyonUretimDetay r)
        {
            _rasyonUretimDataServices.RasyonUretimDetayGuncelle(r);
            return RedirectToAction("RasyonUretimDetayList", new { uretimno = r.URETIMNO, ciftlikno = r.CIFTLIKNO });

        }

        public IActionResult RasyonUretimDetaySil(RasyonUretimDetay r)
        {
            _rasyonUretimDataServices.RasyonUretimDetaySil(r);
            return RedirectToAction("RasyonUretimDetayList", new { uretimno = r.URETIMNO, ciftlikno = r.CIFTLIKNO });
        }


    }
}
