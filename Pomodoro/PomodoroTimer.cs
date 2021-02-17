using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pomodoro
{
    enum StatusType
    {
        OnGoing ,
        Done
    }
    static class PomodoroTimer
    {
        
        public static Timer timer { get; set; }
        private static int workduration;
        public static int WorkDuration
        {
            get { return workduration; }
            set
            {
                if (value > 60 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("work session duration must be between 5 and 60 minutes !");
                }
                workduration = value;
            }
        }

        public static void Start()
        {
            timer = new Timer(PomodoroTimer.StatusChecker, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }
        public static void StatusChecker(object info)
        {

            if (WorkDuration > 0)
            {
                PrintStatus(StatusType.OnGoing);
                WorkDuration--;
            }
            else
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                PrintStatus(StatusType.Done);
            }
        }

        static void PrintStatus(StatusType status)
        {
            Console.Clear();
            Console.WriteLine("\n     This is a Pomodoro Timer \n\n\n");

            switch (status)
            {
                case StatusType.OnGoing:
                    Console.WriteLine($"        {WorkDuration}   minutes is remaining...\n\n        Keep going!");
                    break;
                case StatusType.Done:
                    Console.WriteLine("\n\n\n       Work Session is done ...\n\n        Take a break !!");
                    Console.Beep();
                    Console.Beep();
                    break;
                default:
                    break;
            }
        }

    }
}
