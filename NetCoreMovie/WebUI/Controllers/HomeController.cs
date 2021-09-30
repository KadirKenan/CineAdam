using Common;
using DataAccess.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            _logger = logger;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            //Kayıt işlemi
            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser();
                newUser.UserName = registerVM.UserName;
                newUser.Email = registerVM.Email;

                var result = await userManager.CreateAsync(newUser, registerVM.Password);
                if (result.Succeeded)
                {
                    string mailMessage = $"Merhaba {newUser.UserName}!\nüye olduğunuz için teşekkür ederiz. Lütfen aşağıda gönderilen linki tıklayarak hesabınızı aktif hale getirin.\nhttps://localhost:31685/Home/Activation/{newUser.ActivationCode}";
                    MailSender.SendEmail(registerVM.Email, "Hesap Aktivasyon", mailMessage);

                    return RedirectToAction("PendingAccount", newUser);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }

            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult PendingAccount(AppUser user)
        {
            ViewBag.User = user;
            return View();
        }

        public async Task<IActionResult> Activation(Guid id)
        {

            if (userManager.Users.Any(x => x.ActivationCode == id))
            {
                AppUser user = userManager.Users.Where(x => x.ActivationCode == id).FirstOrDefault();
                user.EmailConfirmed = true;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["success"] = "Hesabınız aktifleştirildi";
                    return RedirectToAction("Login");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View();
            }

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        TempData["success"] = $"Hoşgeldin {user.UserName}";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("failedLogin", "şifre hatalı!");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("notFound", "böyle bir kullanıcı bulunamadı!");
                }
            }
            return View();
        }
    }

}


