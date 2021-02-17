using System;
using System.Threading;

namespace Pomodoro
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("\n     This is a Pomodoro Timer \n\n\n");
            
            ConfigurePomoTimer();
            PomodoroTimer.Start();
            Console.ReadLine();
        }

        static int GetDurationValue()
        {
            Console.Write("     Please Enter the work Session Duration  in minute :    ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void ConfigurePomoTimer()
        {
            PomodoroTimer.WorkDuration = GetDurationValue();
        }
        

    }
}
