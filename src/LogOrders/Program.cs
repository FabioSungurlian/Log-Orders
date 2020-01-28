using System;
using System.Threading;

namespace LogOrders
{
    class Program
    {
        public static bool finished = false;
        static void Main(string[] args)
        {
            Wait.Print("Bienvenido a un nuevo día en la aplicación de escritura de pedidos número 1.");
            Wait.Print("Porfavor sientete libre de pedir todo lo que quieras");
            Wait.Print("1. ¿¡Incluido un unicornio?!");
            Wait.Print("2. No creo que sea interesante...");
            Wait.Print("(escribe el número de la opción que desees...)");
            string input = Console.ReadLine();
            if(input == "1")
            {
                Wait.Print("No... ¡Pero ese es el espíritu!");
            }
            else if(input == "2")
            {
                Wait.Print("Veo que no entraste sin saber lo que te deparaba...");
            }
            else
            {
                Wait.Print("Creo que no te entiendo...");
                Wait.Print("Bueno...");
            }
            while(!finished)
            {
                Order order = new Order();
                order.MakeOrder();
            }
        }
        


    }
}
