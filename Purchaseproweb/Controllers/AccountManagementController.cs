﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System;
using Purchaseproweb.Entities;
using Purchaseproweb.Enum;
using Purchaseproweb.Models;
using Purchaseproweb.Services;

namespace Purchaseproweb.Controllers
{
    [Authorize]
    public class AccountManagementController : BaseController
    {
        private readonly Wemanageservices bl;
        public AccountManagementController(IConfiguration config)
        {
            bl = new Wemanageservices(config);
        }
        #region User Signin
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Signinuser(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signinuser(Userloginmodel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var resp = await bl.Validateuser(model);
            if (resp.Respstatus == 200)
            {
                if (resp.Usermodel.Loginstatus == (int)UserLoginStatus.ChangePassword)
                {
                    return RedirectToAction("Resetuserpassword", new Staffresetpassword() { Code = Guid.NewGuid(), Staffid = resp.Usermodel.Staffid });
                }
                else
                {
                    SetUserLoggedIn(resp, false);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home", new { area = "" });
                    }
                }
            }
            else if (resp.Respstatus == 401)
            {
                Warning(resp.RespMessage, true);
            }
            else
            {
                ModelState.AddModelError(string.Empty, resp.RespMessage);
            }
            return View();

        }
        #endregion

        #region User Reset Password
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Resetuserpassword(Staffresetpassword model)
        {
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Resetuserpasswordpost(Staffresetpassword model)
        {
            var resp = await bl.Resetuserpasswordpost(model);
            if (resp.RespStatus == 0)
            {
                return RedirectToAction("Signinuser");
            }
            else
            {
                ModelState.AddModelError(string.Empty, resp.RespMessage);
            }
            return RedirectToAction("Resetuserpassword", model);

        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Forgotpassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Forgotpassword(Staffforgotpassword model)
        {
            var resp = await bl.Forgotpasswordpost(model);
            if (resp.Respstatus == 200)
            {
                Success("Username and Password has been sent to your Email. Use them to login and set a password you can remember.", true);
                return RedirectToAction("Signinuser");
            }
            else
            {
                Danger("No user has been found with provided username", true);
                ModelState.AddModelError(string.Empty, resp.RespMessage);
            }
            return View(model);

        }
        #endregion


        #region Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Signinuser), "AccountManagement");
        }
        #endregion

        #region Other Methods

        private async void SetUserLoggedIn(UsermodelResponce user, bool rememberMe)
        {
            string userData = JsonConvert.SerializeObject(user);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Usermodel.Staffid.ToString()),
                new Claim(ClaimTypes.Name, user.Usermodel.Fullname),
                new Claim("FullNames", user.Usermodel.Fullname),
                new Claim("Token", user.Token),
                new Claim("userData", userData),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie");

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity[] { claimsIdentity });
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
            new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = new DateTimeOffset?(DateTime.UtcNow.AddMinutes(30))
            });
        }
        //private IActionResult RedirectToLocal(string returnUrl, long Roleid, bool iscustomer)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        if (Roleid > 1 && !iscustomer)
        //        {
        //            return RedirectToAction(nameof(HomeController.Index), "Home", new { area = "" });
        //        }
        //        else
        //        {
        //            return RedirectToAction(nameof(CustomerManagementController.Index), "CustomerManagement", new { area = "" });
        //        }

        //    }
        //}
        #endregion
    }
}
