using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopService
{
    class RegCheck
    {
        AddFirewallRule add = new AddFirewallRule();
        
        public void RegCheckValue()
        {
            RegistryKey check = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            int isEnable = (int)check.GetValue("EnableLUA");
            if (isEnable != 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("UAC отключен!");
                add.addRule();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("UAC включен!");
                SetValueRegedit();
            }          
        }

        public void SetValueRegedit()         
        {
            string yes = "1";
            Console.Write("Вам необходимо отключить UAC в реестре. Да - нажмите 1, Enter или любой символ - чтоб выйти из программы: ");
            string UAC = Console.ReadLine();
            if (yes == UAC)
            {
                _ = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                RegistryKey uac;
                {
                    uac = Registry.LocalMachine.CreateSubKey(("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"));
                }
                uac.SetValue("EnableLUA", 0);
                uac.Close();       
            }
            if (yes != UAC)
            {
                Environment.Exit(0);        
            }
        }
    }
}
