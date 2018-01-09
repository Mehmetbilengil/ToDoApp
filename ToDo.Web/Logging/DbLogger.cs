using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDo.BusinessService.Implementations;

namespace ToDo.Web.Logging
{
    public class DbLogger : IExceptionLogger
    {

        public void LogError(string actionName, Exception ex)
        {
            var service = new ErrorLogService();
            service.LogException(actionName, ex);

        }
    }
}