using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MoluEt.services;
using System.Security.Claims;

namespace MoluEt.Controllers
{
    public class LoginController : Controller
    {
        KullaniciDataServices _kullaniciDataServices = new KullaniciDataServices();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string kullaniciadi, string sifre)
        {
            
            foreach (var item in _kullaniciDataServices.GetList())
            {
                if (item.KULAD == kullaniciadi && item.SIFRE.Trim() == sifre)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, item.SIRKETNO.ToString()),
                        new Claim("kullanicino",item.KULNO.ToString())
                        //new Claim(ClaimsIdentity.DefaultNameClaimType , item.SIRKETNO.ToString()),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProparties = new AuthenticationProperties();

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProparties);
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ModelState.AddModelError("Error", "Kullanıcı Adı veya Şifre Hatalı");
                    
                    
                }
            }
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
