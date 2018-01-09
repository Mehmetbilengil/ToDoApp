using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.BusinessService;
using ToDo.ViewModel;

namespace ToDo.Web.Controllers
{
    public class TaskController : BaseController
    {
        readonly ITaskService service;
        public TaskController()
        {
            service = new TaskService();
        }
      
        
        public JsonResult GetList(Guid listId)
        {
            var list = service.GetList(listId,UserId);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(ToDoTaskEditView model)
        {
            if (!ModelState.IsValid)
            {
                return AJAXResult(false, GetModelStateError());
            }
            if (model.NotificationRequested)
            {
                if (model.NotificationDate == null || model.NotificationDate == default(DateTime))
                {
                    return AJAXResult(false,"Please specify norification date.");
                }
                if (model.NotificationTime == null || model.NotificationTime == default(DateTime))
                {
                    return AJAXResult(false, "Please specify norification time.");
                }
                var date = model.NotificationDate.Value;
                var time = model.NotificationTime.Value;
                model.NotificationDate = new DateTime(date.Year,date.Month,date.Day,time.Hour,time.Minute,0);
                if (model.NotificationDate.Value<DateTime.Now)
                {
                    return AJAXResult(false, "Norification date must be in future.");
                }
            }
            model.UserId = UserId;
            var result = service.Save(model);
            return AJAXResult(_result: result.ResultType == ResultType.Success, _message: result.ResultMessage, _data: new { model.Id });
        }

        [HttpPost]
        public JsonResult Update(ToDoTaskEditView model)
        {
            if (!ModelState.IsValid)
            {
                return AJAXResult(false, GetModelStateError());
            }
            if (model.NotificationRequested)
            {
                if (model.NotificationDate == null || model.NotificationDate == default(DateTime))
                {
                    return AJAXResult(false, "Please specify norification date.");
                }
                if (model.NotificationTime == null || model.NotificationTime == default(DateTime))
                {
                    return AJAXResult(false, "Please specify norification time.");
                }
                var date = model.NotificationDate.Value;
                var time = model.NotificationTime.Value;
                model.NotificationDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
                if (model.NotificationDate.Value < DateTime.Now)
                {
                    return AJAXResult(false, "Norification date must be in future.");
                }
            }
            model.UserId = UserId;
            var result = service.Update(model);

            return AJAXResult(_result: result.ResultType == ResultType.Success, _message: result.ResultMessage);
        }

        [HttpPost]
        public JsonResult Remove(Guid id)
        {
            var result = service.Remove(id, UserId);

            return AJAXResult(_result: result.ResultType == ResultType.Success, _message: result.ResultMessage);
        }
       

    }
}