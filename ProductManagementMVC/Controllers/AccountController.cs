using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services;

namespace ProductManagementMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if(!userId.IsNullOrEmpty())
            {
                return Redirect("/products");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountMember model)
        {


            var user = _accountService.GetAccountById(model.MemberId);

            if(user != null && user.MemberPassword == model.MemberPassword)
            {
                // Store user information in session
                HttpContext.Session.SetString("UserId", user.MemberId);
                HttpContext.Session.SetString("Username", user.FullName);

                return Redirect("/products");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }


            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session data
            return RedirectToAction("Login");
        }



    }
}
