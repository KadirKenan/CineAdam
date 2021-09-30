using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MailSender
    {
        public static void SendEmail(string email, string subject, string message)
        {
            //MailMessage
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress("ba.yzl3148@gmail.com", "YZL3148");
            sender.To.Add(email);
            sender.Subject = subject;
            sender.Body = message;

            //SmtpClient
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("ba.yzl3148@gmail.com", "Yzl3148!!--");
            smtp.Port = 587;//ssl
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            //Not!!!!!!!!!!!!!!!!
            //Eğer tanımlı gmail hesabınız üzerinden mail göndermek isterseniz aşağıdaki linki tıklayarak izin işlemini aktif etmeniz gerekmektedir.
            //https://www.google.com/settings/security/lesssecureapps

            smtp.Send(sender);
        }
    }
}
