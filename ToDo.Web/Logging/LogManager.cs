using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ToDo.Web.Logging
{
    public static class LogManager
    {
        private static readonly IExceptionLogger _logger;

        static LogManager()
        {
          //  _logger= new Log4NetLogger();
            _logger= new DbLogger();
        }

        public static void LogException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];

            Task.Factory.StartNew(() =>
            {
                _logger.LogError($"actionName:{controllerName}.{actionName}", filterContext.Exception);
            });


        }
       
    }
}