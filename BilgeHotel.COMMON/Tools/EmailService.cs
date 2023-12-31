﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.COMMON.Tools
{
    public static class EmailService
    {
        public static void Send(string receiver, string password = "atlkbjteiruyhcww", string body = "Test mesajıdır", string subject = "Email Testi", string sender = "yzl3157test@gmail.com")
        {

            //outlook hesap (KAPANMIŞ HOCAM)
            /*
                yzl3162@outlook.com
                Kadikoy--
             */

            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            //Bizim Email işlemlerimiz SMTP'ye göre yapılır...
            //Kullandıgınız gmail hesabının baska uygulamalar tarafından mesaj gönderme özelligini acmalısınız...

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };


            MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            };
            
                smtp.Send(message);

        }

        public static void ResetPassword(string receiver, string password = "atlkbjteiruyhcww", string body = "Şifre Değişikliği", string subject = "Email Testi", string sender = "yzl3157test@gmail.com")
        {
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };


            MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            };

            smtp.Send(message);
        }

    }
}
