using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ToDo.BusinessService;
using ToDo.ViewModel;
using ToDo.Web.Helpers;

namespace ToDo.Web.Controllers
{
    public class AccountController : BaseController
    {

        readonly IUserAccountService accountService;
        readonly AuthenticationHelper authHepler;

        public AccountController()
        {
        
            var auth = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            authHepler = new AuthenticationHelper(auth);
            accountService = new UserAccountService();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
           
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

                var result = accountService.Create(model);
                if (result.ResultType == ResultType.Success)
                {
                    //authHepler.Login();
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Result = result.ResultMessage;
            }

            return View(model);
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
                       
            var result = accountService.GetUser(model);
            if (result.ResultType == ResultType.Success)
            {

                authHepler.Login(result.Id,result.LastName);
             
                return RedirectToAction("Index", "Home");
            }
            else
            {
               
                ViewBag.Result = result.ResultMessage;
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            authHepler.Logout();
            return RedirectToAction("Login");
        }

    }
}