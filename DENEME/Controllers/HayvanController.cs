using Microsoft.AspNetCore.Mvc;
using MoluEt.services;
using System.DirectoryServices.Protocols;
using X.PagedList.Extensions;

namespace MoluEt.Controllers
{
    public class HayvanController : Controller
    {
        HayvanDataServices _hayvanDataServices = new HayvanDataServices();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HayvanList(int page = 1)
        {
            return View(_hayvanDataServices.GetList().ToPagedList(page,10));
        }

        public IActionResult HayvanDetay()
        {
            return View();
        }
    }
}
