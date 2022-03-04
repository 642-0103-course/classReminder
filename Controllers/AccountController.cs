using Auth0.AspNetCore.Authentication;
using Event_Management.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Event_Management.Controllers
{
    public class AccountController : Controller
    {
        //private UserManager<ApplicationUser> _userManager;
        //private SignInManager<ApplicationUser> _signInManager;

        //public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        //{
        //    this._userManager = userManager;
        //    this._signInManager = signInManager;
        //}




        //public IActionResult Login()
        //{
        //    return View();
        //}



        [Authorize]
        public IActionResult Profile()
        {
            return View(new UserProfileViewModel()
            {
                Name = User.Identity.Name,
                EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value
            });
        }

        public async Task Login(string returnUrl = "/")
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnUrl)
                .Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login([Required][EmailAddress] string email, [Required] string password, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ApplicationUser appUser = await _userManager.FindByEmailAsync(email);
        //        if (appUser != null)
        //        {
        //            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
        //            {
        //                HttpContext.Session.SetString("UserId", appUser.Id.ToString());
        //            }
        //            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, password, false, false);
        //            if (result.Succeeded)
        //            {

        //                return Redirect(returnUrl ?? "/");
        //            }
        //        }
        //        ModelState.AddModelError(nameof(email), "Login Failed: Invalid Email or Password");
        //    }
        //    return View();
        //}

        //[Authorize]
        //public async Task<IActionResult> LogOut()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}


        [Authorize]
        public async Task Logout()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                // Indicate here where Auth0 should redirect the user after a logout.
                // Note that the resulting absolute Uri must be whitelisted in 
                .WithRedirectUri(Url.Action("Index", "Home"))
                .Build();

            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        [Authorize]
        public IActionResult Claims()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
