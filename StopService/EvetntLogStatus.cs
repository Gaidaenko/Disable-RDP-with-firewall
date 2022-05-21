using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopService
{    
    public class EvetntLogStatus
    {

        SendingMail sending = new SendingMail();
        public  void EventLogStop()
        {
            string UserID = Environment.UserName;
            string Event = "Внимание: Пользователь остановил работу сервера. Имя пользователя " + UserID;
            string Source = "AppStopWork";
            string Log = "App";
            if (!EventLog.SourceExists(Source))
                 EventLog.CreateEventSource(Source, Log);
            using (EventLog eventLog = new EventLog("App"))
            {
                eventLog.Source = "AppStopWork"; 
                eventLog.WriteEntry(Event, EventLogEntryType.Warning);
                Console.WriteLine("Действие занесено в журнал событий Windows, в раздел App, и отправлено на почту администратору.");
                sending.SendStop();
                return;
            }
        }
        public void EventLogError()
        {
            string UserID = Environment.UserName;
            string Event = "Внимание: Попытка остановить работу сервера завершилась неудачей. Возможно правило блокировки уже существует.";
            string Source = "AppStopWork";
            string Log = "App";
            if (!EventLog.SourceExists(Source))
                 EventLog.CreateEventSource(Source, Log);
            using (EventLog eventLog = new EventLog("App"))
            {
                eventLog.Source = "AppStopWork"; 
                eventLog.WriteEntry(Event, EventLogEntryType.Error);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Действие занесено в журнал событий Windows, в раздел App, и отправлено на почту администратору. Имя пользователя: {0}", UserID);
                sending.SendStop();
            }
        }
    }
}
