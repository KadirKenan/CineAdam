using DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(SignInManager<AppUser> _signInManager)
        {
            signInManager = _signInManager;
        }
        public IActionResult Profile(string Name)
        {
            //todo: Profil sayfası oluşturulacak.
            if (signInManager.IsSignedIn(User))
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Reservation(string Name)
        {
            //todo: Rezervasyon sayfası oluşturulacak.
            if (signInManager.IsSignedIn(User))
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut(string Name)
        {
            if (signInManager.IsSignedIn(User))
            {
               await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
