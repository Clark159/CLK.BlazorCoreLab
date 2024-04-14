using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace MDP.HybridLab.WebApp
{
    public class AccountController : Controller
    {
        // Methods
        public IActionResult Login(string returnUrl)
        {
            // Return
            return View();
        }

        public async Task<IActionResult> LoginByPassword()
        {
            // ClaimsIdentity
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Clark"),
                new Claim(ClaimTypes.Role, "Admin"),
            }
            , "TestAuth");

            // SignIn
            await this.HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

            // Return
            return this.RedirectToAction("Index", "Home");
        }
    }
}
