using System.Threading.Tasks;
using DreamsBytes.ECommerce.DTOs.Concrete.AppUserDtos;
using DreamsBytes.ECommerce.Entities.Concrete;
using DreamsBytes.ECommerce.WebUI.BaseControllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DreamsBytes.ECommerce.WebUI.Controllers
{
    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : base(userManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password,false,false);

                    if (identityResult.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);

                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("ProductList", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }                
            }

            return View("Index", model);
        }
       
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}