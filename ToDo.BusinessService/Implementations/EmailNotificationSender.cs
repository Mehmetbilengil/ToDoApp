using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.BusinessService.Utility;
using ToDo.Common;
using ToDo.DomainModel;
using ToDo.Repository;

namespace ToDo.BusinessService.Implementations
{
    public class EmailNotificationSender : INotificationSender
    {
        public Task<int> Send()
        {
            using (var repo = new ToDoRepository<ToDoTask>())
            {
                var list = repo.Query(o => o.NotificationRequested
                                    && o.NotificationType == NotificationType.Email
                                    && o.NotificationDate <= DateTime.Now
                ).Select(o => new EmailNotficationData
                {
                    Id = o.Id,
                    Desc = o.Desc,
                    NotificationDate = o.NotificationDate,
                    Email = o.List.User.Email,
                    LastName = o.List.User.LastName

                }).ToList();
                var emailSender = new EmailSender();
                Parallel.ForEach(list, (item) =>
                {
                    Send(emailSender,item);
                });

                return Task.FromResult(list.Count);

            }
        }
        class EmailNotficationData
        {
            public Guid Id { get; internal set; }
            public string Desc { get; internal set; }
            public DateTime? NotificationDate { get; internal set; }
            public string Email { get; internal set; }
            public string LastName { get; internal set; }
        }
        private void Send(EmailSender emailSender, EmailNotficationData item)
        {
            using (var repo = new ToDoRepository<ToDoTask>())
            {
                var emailSubject = $"Remainder for your task:{item.Desc}";
                var emailContent = $"This is remainder for your task:{item.Desc}";
                var content = EmailBody.Replace("{TITLE}", item.LastName).Replace("{CONTENT}", emailContent);

              var result=  emailSender.Send(item.Email, emailSubject, content);

                if (result)
                {
                    var task = repo.SingleOrDefault(o=>o.Id==item.Id);
                    task.NotificationSent = true;
                    task.NotificationSentDate = DateTime.Now;
                    repo.SaveChanges();
                }

            }
        }
        internal const string EmailBody = @"
                                <html xmlns='http://www.w3.org/1999/xhtml' lang='en'>
                                <head>
                                    <title></title>
                                </head>
                                <body style='font-family:sans-serif,Verdana,Tahoma;color:#333'>
                                    <div style='border-color:#666; background-color:azure; border-style:dashed; border-width:1px; width:90%; padding:20px'>
                                     <table style='width:100%'>
                                         <tr>
                                             <td colspan='2'>
                                                   <h3>{TITLE}</h3>
                                                   <p> {CONTENT}</p>
                                             </td>
                                         </tr>
                                        
                                          <tr>
                                             <td>
                                             </td>
                                              <td style='padding:10px'>
                                             </td>
                                         </tr>
                                     </table>
                                    </div>
                                </body>
                                </html>";

    }


}
