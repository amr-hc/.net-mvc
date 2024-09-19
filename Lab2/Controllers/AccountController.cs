using Lab2.Models;
using Lab2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManger;
        private SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManger , SignInManager<ApplicationUser> signInManager) { 
            
            this.userManger=userManger;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewMode registerdata) {
            if (ModelState.IsValid) {

                ApplicationUser newUser = new ApplicationUser();
                newUser.Email = registerdata.Email;
                newUser.UserName = registerdata.UserName;
                newUser.Address = registerdata.Address;
                //newUser.PasswordHash = registerdata.Password;

                IdentityResult res = await userManger.CreateAsync(newUser, registerdata.Password);

                if (res.Succeeded)
                {
                    await signInManager.SignInAsync(newUser, false);
                    return RedirectToAction("index", "course");
                }

                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

                return View("Register", registerdata);
            
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginvm)
        {

            if (ModelState.IsValid) {

                ApplicationUser user = await userManger.FindByEmailAsync(loginvm.Email);
                
                if(user != null)
                {
                    bool found = await userManger.CheckPasswordAsync(user, loginvm.Password);
                    if (found) {
                        await signInManager.SignInAsync(user, loginvm.RemeberMe);
                        return RedirectToAction("index", "course");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email or Password Wrong");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email not Found");
                }


            }

            return View("login", loginvm);
        }





    }
}
