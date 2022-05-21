using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopService
{
    class Validations
    {
        public string validName = "SERVER";
        public string serverName = Environment.MachineName;

        public void ValidName()
        {
            Program registry = new Program();
            
            if (serverName == validName)
            {
                registry.RegCheck();
            }
            if (serverName != validName)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("НЕ ПРЕДНАЗНАЧЕНО ДЛЯ ИСПОЛЬЗОВАНИЯ НА ДАННОМ СЕРВЕРЕ!");
                Console.ReadKey();
                Environment.Exit(0);
                return;
            }           
        }        
    }
}
