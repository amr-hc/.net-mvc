using Lab2.Models;
using Lab2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lab2.Controllers
{
    public class RoleController : Controller
    {

        private RoleManager<IdentityRole> roleManager {  get; set; }
        public RoleController(RoleManager<IdentityRole> roleManager) {
            this.roleManager = roleManager;
        }


        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create(RoleViewModel role)
        {
            IdentityRole newrole = new IdentityRole();
            newrole.Name = role.name;
            IdentityResult res =  await roleManager.CreateAsync(newrole);
            if (res.Succeeded)
            {
                return RedirectToAction("index","home");
            }
            foreach(var error in res.Errors){
                ModelState.AddModelError("", error.Description);
            }
            return View("create", role);
        }

        public async Task<IActionResult> beAdmin()
        {
            var x  = User;
            Claim idclaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            

            string name = User.Identity.Name;




            return Content($"You are now an admin!{name}: {idclaim.Value}");
        }
    }

}
