using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace KillProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            string processName;
            int lifeTimeProcess;
            int checkInterval;
            if (args.Length < 3)
            {
                Console.WriteLine("Введите имя отслеживаемого процесса");
                processName = Console.ReadLine();
                Console.WriteLine("Введите время жизни процесса в мин");
                lifeTimeProcess = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите интервал проверки в мин");
                checkInterval = int.Parse(Console.ReadLine());
            }
            else
            {
                processName = args[0];
                lifeTimeProcess = int.Parse(args[1]);
                checkInterval = int.Parse(args[2]);
            }
            Console.WriteLine("Мониторим процесс " + processName);
            while (true)
            {
                Process[] process2 = Process.GetProcesses();
                foreach (Process process in Process.GetProcesses())
                {
                    if (String.Compare(process.ProcessName, processName, true) == 0 && (DateTime.Now - process.StartTime).Seconds > lifeTimeProcess)
                    {
                        try
                        {
                            process.Kill();
                            Console.WriteLine("Процесс " + processName + " работал более чем " + lifeTimeProcess + " мин и был завершен");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("не удалось завершить процесс " + processName);
                        }
                    }
                }
                Thread.Sleep(checkInterval * 60000);
            }

        }
       
    }
}
