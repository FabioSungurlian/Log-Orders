using System.Threading;
using System;

namespace LogOrders 
{
    class Wait{
        static public void Print(string line, int duration = 1000){
            Console.WriteLine(line);
            Thread.Sleep(duration);
        }
    }
}