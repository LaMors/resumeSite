using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace MyResume.Service
{
    public class MailHelper
    {
        private readonly ILogger<MailHelper> logger;

        public MailHelper(ILogger<MailHelper> logger)
        {
            this.logger = logger;
        }

        public void SendEmail(string name, string sender, string subject, string body)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(Config.DocumentName, sender)); //message sender
                message.To.Add(new MailboxAddress("deusvecumest@gmail.com")); //addressee of the message
                message.Subject = subject; //тема сообщения
                message.Body = new BodyBuilder() { HtmlBody = $"<div style=\"color: green;\">{name}: {"\n" + body} .My email: {sender}</div>" }.ToMessageBody(); //message body (also in HTML format)

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true); // or use port 587
                    client.Authenticate("wederkar@gmail.com", "sauda0sakdpj23u9djas"); //логин-пароль от аккаунта
                    client.Send(message);

                    client.Disconnect(true);
                    logger.LogInformation("Сообщение отправлено успешно!");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);
            }
        }
    }
}
