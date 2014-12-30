using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Net.Mail;

/// <summary>
/// Summary description for SendMail
/// </summary>
public class SendMail
{
	public SendMail()
	{
	}

    public void sendMail(string to, string subject, string body)
    {
        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        using (System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage(new MailAddress(to),
        new MailAddress(to)))
        {
            mailMessage.Body = body;
            mailMessage.Subject = subject;
            try
            {
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Credentials = new System.Net.NetworkCredential("fakeidfortest@yahoo.com", "123456789");
                SmtpServer.Port = 587;


                SmtpServer.Host = "smtp.mail.yahoo.com";
                SmtpServer.EnableSsl = false;

                mail = new System.Net.Mail.MailMessage();
                String[] addr = to.Split(',');
                mail.From = new MailAddress("fakeidfortest@yahoo.com");
                Byte i;
                for (i = 0; i < addr.Length; i++)
                    mail.To.Add(addr[i]);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.ReplyTo = new MailAddress(to);
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
    }
}