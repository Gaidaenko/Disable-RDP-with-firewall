using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace StopService
{
    class SendingMail
    {
        public void SendStop()
        {
            try
            {
                MailAddress from = new MailAddress("appstopwork@yahoo.com", "Company");
                MailAddress to = new MailAddress("recipient@gmail.com");
                MailMessage message = new MailMessage(from, to);

                message.IsBodyHtml = true;
                message.Subject = "Море Суши. Работа сервера ОСТАНОВЛЕНА!";
                message.Body = "Доступ отключил пользователь: " + Environment.UserName +
                               "<br/>" + "Имя сервера: " + Environment.MachineName +
                               "<br/>" + "Время отключения доступа: " + DateTime.Now;
                // "<br/>" + "Время загрузки сервера: " + DateTime.Now.AddMilliseconds(-Environment.TickCount);

                SmtpClient smtp = new SmtpClient("smtp.mail.yahoo.com", 587);
                smtp.Credentials = new NetworkCredential("appstopwork@yahoo.com", "PrivatPassword");
                smtp.EnableSsl = true;
                smtp.Send(message);
                return;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("УВЕДОМЛЕНИЕ АДМИНИСТРАТОРУ НЕ ОТПРАВЛЕНО!");
                Console.ReadLine();
                return;
            }
        }
        public void SendError()
        {
            try
            {
                MailAddress from = new MailAddress("appstopwork@yahoo.com", "Company");
                MailAddress to = new MailAddress("recipient@gmail.com");
                MailMessage message = new MailMessage(from, to);

                message.IsBodyHtml = true;
                message.Subject = "Попытка отключить доступ к серверу: " + Environment.MachineName;
                message.Body = "Попытка отключить доступ к серверу: " + Environment.MachineName + " от имени пользователя " + Environment.UserName + " завершилась неудачей!" +
                               "<br/>" + "Имя сервера: " + Environment.MachineName +
                               "<br/>" + "Время отключения доступа: " + DateTime.Now;
                // "<br/>" + "Время загрузки сервера: " + DateTime.Now.AddMilliseconds(-Environment.TickCount);

                SmtpClient smtp = new SmtpClient("smtp.mail.yahoo.com", 587);
                smtp.Credentials = new NetworkCredential("appstopwork@yahoo.com", "PrivatPassword");
                smtp.EnableSsl = true;
                smtp.Send(message);
                return;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("УВЕДОМЛЕНИЕ АДМИНИСТРАТОРУ НЕ ОТПРАВЛЕНО!");
                Console.ReadLine();
                return;
            }
        }
    }
}
