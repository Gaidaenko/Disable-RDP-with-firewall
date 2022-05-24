using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFirewallHelper;

namespace StopService
{  
    public class AddFirewallRule
    {
        EvetntLogStatus logStatus = new EvetntLogStatus();
        SendingMail sendingMail = new SendingMail();
        public void addRule()
        {

            try
            {
                var rules = FirewallManager.Instance.CreatePortRule(FirewallProfiles.Private, "TestUser_" + Environment.UserName, FirewallAction.Block, 3389, FirewallProtocol.TCP);

                rules.Direction = FirewallDirection.Inbound;
                FirewallManager.Instance.Rules.Add(rules);
                logStatus.EventLogStop();
                sendingMail.SendStop();
            }
            catch
            {
                logStatus.EventLogError();
                sendingMail.SendError();
                return;
            }





            /* string firewallAddRule = $"netsh advfirewall firewall add rule name=\"{Environment.UserName}_ОТКЛЮЧИЛ ДОСТУП К СЕРВЕРУ!\" protocol=TCP localport=3389 action=block dir=IN";

            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.Verb = "runas";
                proc.UseShellExecute = true;
                proc.WorkingDirectory = @"C:\Windows\System32";
                proc.FileName = @"C:\Windows\System32\cmd.exe";
                proc.Arguments = "/c " + firewallAddRule;
                proc.WindowStyle = ProcessWindowStyle.Hidden;

                Process.Start(proc);
                logStatus.EventLogStop();
            }
            catch(Exception e)
            {              
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("НЕ УДАЛОСЬ ОТКЛЮЧИТЬ ДОСТУП!");
                Console.ReadKey();
                logStatus.EventLogError();               
                return;
            } */
        }
    }
}
