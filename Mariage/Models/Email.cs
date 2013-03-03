using System.Net.Mail;
using System.Web;

namespace Mariage.Models
{
    public static class Email
    {
        public static void Send(string sender, string subject, string body, HttpPostedFileBase file)
        {
            var mail = new MailMessage
            {
                From = new MailAddress("gbrl.arnaud@gmail.com"),
                Body = body,
                Subject = subject + "Email d'envoi : " + sender,
                IsBodyHtml = false,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess
            };
            if (file != null)
            {
                mail.Attachments.Add(new Attachment(file.InputStream, file.FileName));
            }
            mail.To.Add(new MailAddress("gbrl.arnaud@gmail.com, perrine.rembry@gmail.com"));
            var smtp = new SmtpClient();
            smtp.Send(mail);
        }
    }
}