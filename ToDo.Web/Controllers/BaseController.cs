using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Web.Helpers;
using ToDo.Web.Logging;

namespace ToDo.Web.Controllers
{
    public class BaseController : Controller
    {
     

        protected string GetModelStateError()
        {
            return ModelState.Values.SelectMany(v => v.Errors.Select(o => o.ErrorMessage)).FirstOrDefault();
        }

        protected JsonResult AJAXResult(bool _result, string _message = "", object _data = null)
        {
            return Json(new { result = _result, message = _message, data = _data });

        }

        public Guid UserId
        {
            get
            {

                var authHepler = new AuthenticationHelper();

                return authHepler.GetUserId();

            }
        }
        protected override void OnException(ExceptionContext filterContext)
        {

            LogManager.LogException(filterContext);


            filterContext.ExceptionHandled = true;


            //// Redirect on error:
            //filterContext.Result = RedirectToAction("Error", "Home");

            //// OR set the result without redirection:
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
      


    }
}