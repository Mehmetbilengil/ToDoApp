using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ToDo.BusinessService.Settings;

namespace ToDo.BusinessService.Utility
{
    public class EmailSender 
    {
        readonly EmailSettings settings;
        public EmailSender( )
        {
            settings = EmailSettings.GetSettings();
        }
        public bool Send(string receiver, string subject, string content)
        {


            var message = new MailMessage();
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Subject = subject;

            message.To.Add(receiver);

            message.From = new MailAddress(settings.FromEmail, settings.DisplayName);

            message.Body = content;


            var credentials = new System.Net.NetworkCredential();

            credentials.UserName = settings.EmailUser;
            credentials.Password = settings.EmailPassword;


            var smtp = new SmtpClient(settings.SMTPServer, settings.SMTPPort);
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = settings.UseSSL;
            smtp.Credentials = credentials;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                smtp.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

      
    }

   
}