﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace rentacar.Services
{
    public class MailHelper
    {
        public static void SendMail(string emailTo, string message, string ccMail )
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential("razvoj.softvera1@gmail.com", "razvojsoftvera11");
            SmtpServer.EnableSsl = true;
            string mailFrom = "test@test.com";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(mailFrom);
            mail.To.Add(emailTo);
            mail.Subject = "Mail sa stranice";
            mail.CC.Add(ccMail);
            mail.Body += " <html>";
            mail.Body += "<body>";
            mail.Body += "<p>" + message + "</p>";
            mail.Body += "</body>";
            mail.Body += "</html>";
            mail.IsBodyHtml = true;

            SmtpServer.Send(mail);
        }
    }
}
