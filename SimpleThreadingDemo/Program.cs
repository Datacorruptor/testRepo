using System;
using System.Text;
using System.Threading;

namespace SimpleThreadingDemo
{
    class Program
    {
        static void Clear(string text, int x, int y)
        {
            //Sets the cursor position
            Console.SetCursorPosition(x, y);

            //Writes the blank string over the old string
            Console.WriteLine(text);

            //Resets cursor position
            Console.SetCursorPosition(0, 0);
        }
        static int x = 5,y = 0;
        static void Counting() {
            Thread.Sleep(3000);
            double speed = 150;
            while (y<x) {
                y++;
                speed *= 0.995;
                if(speed<100)speed *= 1.001;
                if (speed < 60) speed *= 1.001;
                if (speed < 30) speed *= 1.001;
                if (speed < 20) speed *= 1.001;
                if (speed < 15) speed *= 1.001;
                if (speed < 10) speed *= 1.001;
                if (speed < 5) speed *= 1.00001;
                Clear("                      ", 0, 0);
                Console.WriteLine(x + " " + y);
                Thread.Sleep((int)speed+1);
            }
            
        }
        static void Main(string[] args)
        {
           
            Console.CursorVisible = false;
            ThreadStart starter = new ThreadStart(Counting);
            Thread first = new Thread(starter);

            first.Start();
            Console.WriteLine(x + " " + y);
            while (true)
            {
                Console.ReadKey();
                if (x == y)
                    break;
                Clear("   ", 0, 1);
                x++;
                Clear("                   ", 0, 0);
                Console.WriteLine(x + " " + y);
            }

            first.Join();
            while (true)
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;

        }
    }
}
