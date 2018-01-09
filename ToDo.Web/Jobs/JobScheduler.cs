using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ToDo.Web.Jobs
{
    public static class JobScheduler
    {
        public static async Task StartSchedule()
        {
            
            var props = new NameValueCollection
                                    {
                                        { "quartz.serializer.type", "binary" }
                                    };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);

            // get a scheduler
            IScheduler sched = await factory.GetScheduler();
            await sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<NotificationJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("myTrigger", "group1")
              .StartNow()
              .WithSimpleSchedule(x => x
                  .WithIntervalInSeconds(60)
                  .RepeatForever())
              .Build();

            await sched.ScheduleJob(job, trigger);
        }
    }
}