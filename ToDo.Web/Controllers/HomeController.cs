using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.BusinessService;
using ToDo.ViewModel;

namespace ToDo.Web.Controllers
{
    public class HomeController : BaseController
    {
        readonly IToDoListService service;
        public HomeController()
        {
            service = new ToDoListService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetToDoList()
        {
            var list = service.GetList(UserId);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(ToDoItemEditView model)
        {
            if (!ModelState.IsValid)
            {
                return AJAXResult(false, GetModelStateError());
            }
            var result = service.Save(model, UserId);
            return AJAXResult(_result: result.ResultType == ResultType.Success, _message: result.ResultMessage, _data: new { model.Id });
        }

        [HttpPost]
        public JsonResult Update(ToDoItemEditView model)
        {
            if (!ModelState.IsValid)
            {
                return AJAXResult(false, GetModelStateError());
            }

            var result = service.Update(model, UserId);

            return AJAXResult(_result: result.ResultType == ResultType.Success, _message: result.ResultMessage);
        }

        [HttpPost]
        public JsonResult Remove(Guid id)
        {

            var result = service.Remove(id, UserId);

            return AJAXResult(_result: result.ResultType == ResultType.Success, _message: result.ResultMessage);
        }

        //
        public ActionResult Details(Guid id)
        {
            var model = service.GetDetails(id, UserId);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

    }
}