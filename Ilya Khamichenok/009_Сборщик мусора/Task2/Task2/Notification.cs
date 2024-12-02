using System.Diagnostics;
using System.Timers;

namespace Task2
{
    public static class Notification
    {
        private static System.Timers.Timer aTimer;
        private static long size;

        public static void Initialize(long sizeMemory)
        {
            size = sizeMemory;
            SetTimer();
        }

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(20);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var currentProc = Process.GetCurrentProcess();
            var memoryUsed = currentProc.WorkingSet64;

            if (size >= memoryUsed)
            {
                Console.Write("Объем потребляемой памяти: " + memoryUsed + " Все в норме." + "\r");
            }
            else
            {
                Console.Write("Объем потребляемой памяти: " + memoryUsed + " WARNING!!!" + "\r");
            }
        }
    }
}
