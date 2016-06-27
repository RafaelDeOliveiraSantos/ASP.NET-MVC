using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TreinamentoBenner.Models;

namespace TreinamentoBenner.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            //Session["Usuario"] = new Usuario();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == "danilobgi@gmail.com" && model.Password == "123")
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "Usuário ou senha incorretos");
            }
            return View(model);

        }

        public ActionResult LogOff()
        {
            Logout();
            return RedirectToAction("Index", "Home");
        }

        private void Logout()
        {
            if (Response.IsRequestBeingRedirected)
                return;
            FormsAuthentication.SignOut();
            //Session["Usuario"] = null;
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}