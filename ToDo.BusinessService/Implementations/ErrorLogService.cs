using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Common;
using ToDo.DomainModel;
using ToDo.Repository;

namespace ToDo.BusinessService.Implementations
{
    public class ErrorLogService
    {
        public void LogException(string actionName, Exception ex)
        {
            if (ex == null)
            {
                return;
            }
            using (var repo = new ToDoRepository<ErrorLog>())
            {

                actionName = actionName.ShortenString(150);

                var innerException = ex.GetInnerException();
                var message = innerException.Message.ShortenString(200);
                var stackTrace = innerException.StackTrace.ShortenString(500);

                var log = new ErrorLog()
                {
                    ActionName = actionName,
                    Message = message,
                    StackTrace = stackTrace
                };

                repo.Add(log);
                repo.SaveChanges();
            }
        }
    }
}
