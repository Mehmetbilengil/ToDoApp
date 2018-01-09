using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.Web.Logging
{
    public class Log4NetLogger : IExceptionLogger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      

        public void LogError(string actionName, Exception ex)
        {
            log.Error(actionName, ex);
        }
    }
}