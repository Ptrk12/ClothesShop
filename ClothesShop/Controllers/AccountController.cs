using ClothesShop.Data;
using ClothesShop.Data.Static;
using ClothesShop.Data.ViewModels;
using ClothesShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            var result = new LoginVM();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAdress);
            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user,loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,loginVM.Password,false,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Clothes");
                    }
                }
                TempData["Error"] = "Try again";
                return View(loginVM);
            }
            TempData["Error"] = "Try again";
            return View(loginVM);
        }
        public IActionResult Register()
        {
            var result = new RegisterVM();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAdress);
            if (user != null)
            {
                TempData["Error"] = "Error";
                return View(registerVM);
            }
            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAdress,
                UserName = registerVM.EmailAdress
            };
            var newUserResult = await _userManager.CreateAsync(newUser, registerVM.Password);
            if(newUserResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            return View("RegisterCompleted");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Clothes");
        }
    }
}
