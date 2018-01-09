using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ToDo.BusinessService.Implementations;

namespace ToDo.Web.Jobs
{
   
    public class NotificationJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {

            INotificationSender notificationSender = new EmailNotificationSender();

            await notificationSender.Send();
        }
    }
}