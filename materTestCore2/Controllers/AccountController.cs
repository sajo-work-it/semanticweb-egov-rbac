using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using materTestCore2.Helpers;
using static materTestCore2.Models.EGovModels.SharedClasses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using materTestCore2.Models.EGovModels;

namespace AppMgr.App.Controllers
{
    [AllowAnonymous]
    [System.ComponentModel.Description("الحسابات")]
    public class AccountController : Controller
    {
        HttpClient AuthenticationClient { get; set; } = new HttpClient();



        [AllowAnonymous]
        [System.ComponentModel.Description("تسجيل الدخول")]
        public IActionResult Login()
        {
            //ClaimsPrincipal claimUser = HttpContext.User;

            //if (claimUser.Identity.IsAuthenticated)
            //    return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [System.ComponentModel.Description("تسجيل الدخول")]
        public async Task<ActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                AuthenticationClient.BaseAddress = new Uri("http://localhost:53211/api/Values/remoteLogin");
                Task<authenticationResponse2> response = Functions.LoginApiCall(model, AuthenticationClient);
                if (response.Result.Success == true && response.Result.returnURL != "")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.GivenName, response.Result.FIRSTNAME),
                        new Claim(ClaimTypes.Name, response.Result.USERNAME),
                        new Claim(ClaimTypes.NameIdentifier, response.Result.USERID),
                        new Claim(ClaimTypes.UserData,string.Join("#", response.Result.PERMISSIONS) )
                    };

                    var responseRoles = response.Result.ROLES;
                    for (int i = 0; i < responseRoles.Count; i++)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, responseRoles[i]));
                    }
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal , properties);
                    return Redirect(response.Result.returnURL);
                }
                else
                {
                    if (response.Result.Success == true)
                    {
                        var error = "لا يمتلك المستخدم أي دور فعال.";
                        ViewBag.LoginError = error;
                        ModelState.AddModelError("", error);
                    }
                    else
                    {
                        if (response.Result.Message !=null)
                        {
                            var error = response.Result.Message;
                            ViewBag.LoginError = error;
                            ModelState.AddModelError("", error);
                        }
                        else
                        {
                            var error = "اسم المستخدم أو كلمة المرور غير صحيحة.";
                            ViewBag.LoginError = error;
                            ModelState.AddModelError("", error);
                        }

                    }

                }
            }
            return View(model);
        }

        [System.ComponentModel.Description("إعادة توجيه لطلب غير مصرّح")]
        public ActionResult UnauthorizedRequest(string returnUrl, AuthError? authError = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.AuthError = authError?.GetEnumDescription();
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[System.ComponentModel.Description("تسجيل الخروج")]
        public async Task LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = "Login" });
        }

        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //    //if (Url.IsLocalUrl(returnUrl))
        //    if (true)
        //    {
        //        return Redirect(returnUrl);

        //    }

        //    else
        //    {
        //        return RedirectToAction("Index", "Home", new { Area = "" });
        //    }
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[System.ComponentModel.Description("تسجيل الخروج")]
        //public ActionResult Logout()
        //{
        //    //await _signInManager.SignOutAsync();
        //    //return LocalRedirect("");
        //    AuthenticationClient.BaseAddress = new Uri("http://localhost:53211/api/Values/Logout");
        //    Functions.LogoutApiCall(AuthenticationClient);
        //    return Redirect("login");
        //}

        //[System.ComponentModel.Description("تغيير كلمة المرور")]
        //public ActionResult ChangePassword()
        //{
        //    var model = new ChangePasswordViewModel();
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        using (var db = new FileSystem.AppMgr.AppMgrDbContext())
        //        {
        //            var user = db.Users.FirstOrDefault(u => u.UserName.Trim().Equals(User.Identity.Name));
        //            if (user != null)
        //            {
        //                model.UserId = user.Id;
        //                model.Username = user.UserName;
        //                model.Name = string.Format("{0} {1}", user.FirstName, user.LastName);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "قم بتسجيل الدخول أولاً.");
        //        ViewBag.LoginRequired = true;
        //    }
        //    return View("_ChangePassword", model);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[System.ComponentModel.Description("تغيير كلمة المرور")]
        //public ActionResult ChangePassword(ChangePasswordViewModel model)
        //{
        //    bool success = false;
        //    if (!(User?.Identity?.IsAuthenticated).GetValueOrDefault(false))
        //    {
        //        ModelState.AddModelError("", "قم بتسجيل الدخول أولاً.");
        //        ViewBag.LoginRequired = true;
        //    }
        //    if (ModelState.IsValid && (User?.Identity?.IsAuthenticated).GetValueOrDefault(false))
        //    {
        //        using (var db = new FileSystem.AppMgr.AppMgrDbContext())
        //        {
        //            var user = db.Users.FirstOrDefault(u => u.Id == model.UserId);
        //            if (user != null)
        //            {
        //                var oldHashedPWD = Constants.EncodePasswordMd5(model.OldPassword);
        //                if (!user.Password.Equals(oldHashedPWD, StringComparison.InvariantCultureIgnoreCase))
        //                {
        //                    ModelState.AddModelError("OldPassword", "كلمة المرور القديمة غير صحيحة.");
        //                }
        //                else
        //                {
        //                    var hashedPWD = Constants.EncodePasswordMd5(model.Password);
        //                    user.Password = hashedPWD;
        //                    try
        //                    {
        //                        db.SaveChanges();
        //                        success = true;
        //                    }
        //                    catch (Exception)
        //                    {
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    ViewBag.Success = success;
        //    return PartialView("_ChangePasswordViewModelInfoPartial", model);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}