using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace StopService
{
    class Program
    {
        static void Main(string[] args)
        {
              Validations valid = new Validations();
              valid.ValidName();     
        }
        public void RegCheck()
        {
            RegCheck registryCheck = new RegCheck();
            registryCheck.RegCheckValue();
        }
        
        public void addFirewallRule()
        {
            AddFirewallRule firewallRule = new AddFirewallRule();
            firewallRule.addRule();
        }
 
        public void stopEvetnLog()
        {
            EvetntLogStatus logStatusStop = new EvetntLogStatus();
            logStatusStop.EventLogStop();
        }
        public void SendMailStop()
        {
            SendingMail sendMailStop = new SendingMail();
            sendMailStop.SendStop();
        }   
    }                                 
}
      


    

    





        
    

    
 
























     


