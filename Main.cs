using System;
using Microsoft.Win32;

namespace SetSwitchKey
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Introduction
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("SEB_Bypass version 1.1 - Crille");
            Console.WriteLine("**(Använd på egen risk)**");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine();
            #endregion

            string[] path = new String[] //mer läggs till snart om nödvändigt.
            {
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"
                /*"Settings\\CurrentControlSet\\Services\\RasMan\\Parameters"*/
            };
            string[] keyName = new String[]
            {
                "HideFastUserSwitching"
                /*"KeepRasConnections"*/
            };
            int[] value = new int[]
            {
                0,
                1
            };
            while (true)
            {

                for (int i = 0; i < path.Length; i++)
                {
                    Console.WriteLine(i);
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(path[i]);
                    int read_value = int.Parse(registryKey.GetValue(keyName[i]).ToString());

                    if (read_value != 0)
                    {
                        ChangeKey(path[i], keyName[i], value[i]);
                    }
                }
                System.Threading.Thread.Sleep(4000);
            }
        }
        public static void ChangeKey(string path, string keyName, int value)
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(@path, true);
            rk.SetValue(keyName, value);

            //Skriver ut vad som händer.
            #region Print.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(DateTime.Now);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": Key \" ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(keyName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" \" Changed!");
            #endregion
        }
    }
}
