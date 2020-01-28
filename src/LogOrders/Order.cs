using System;
using System.Threading;
using System.IO;

namespace LogOrders
{
    class Order
    {
        
        private string OrderLog;
        
        
        public void AddOrderInfo (string info)
        {
            OrderLog += info;
        }

        public Order()
        {
            OrderLog = "";
        }
        public void MakeOrder()
        {
            
            Wait.Print("¿Qué es lo que quiere?");
            Wait.Print("1. Quiero comprar algo.");
            Wait.Print("2. Quiero preguntarte algo.");
            Wait.Print("3. Quiero un cupon.");
            Wait.Print("4. Quiero asesinarte.");
            Wait.Print("5. Quiero abandonarte.");
            Wait.Print("6. Quiero eliminar todo registro de que te he hablado alguna vez.");

            var input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    OrderLog += "compró ";
                    var buyManager = new BuyManager(this);      
                    buyManager.BuyRequest();
                    break;
                case "2":
                    OrderLog += "Preguntó algo confidencial.";
                    AskRequest(); 
                    break;
                case "3":
                    OrderLog += "Pidió un cupón, pero no habian.";
                    CouponRequest();       
                    break;
                case "4":
                    OrderLog += "Asesinó a la consola.";
                    MurderRequest();         
                    break;
                case "5":
                    OrderLog += "Abandonó su propia felicidad";
                    AddOrder();
                    Wait.Print("Veo que no podes ser simplemente feliz");
                    Program.finished = true;
                    break;
                case "6":
                    Wait.Print("No sé que he hecho para merecer esto, pero haya voy...");
                    File.WriteAllText("Orders.txt", String.Empty);
                    Wait.Print("Ahora que no hay registros, creo que tendremos que rehacerlos juntos...");
                    break;

                default:
                    Wait.Print("Permiteme que te pregunte una vez más...");
                    Wait.Print("Acuerdate de escribir el número de la opción que desees sin espacios extras");
                    break;
            }

        }

        private void MurderRequest()
        {
            Wait.Print("...");
            Wait.Print("...");
            Wait.Print("Veo que ha llegado la hora");
            Wait.Print("Uff...");
            Wait.Print("¡¡ HARAKIRI !!");
            Wait.Print("Buenos días, soy Jimmy Jones, el hermano de Jimmy Jones. ");
            Wait.Print("Lamento lo que ha pasado y vengo a suplantar a mi hermano.");
            AddOrder();
        }

        private void CouponRequest()
        {
            Wait.Print("Lo siento, no nos quedan cupones");
            AddOrder();
        }

        

        private void AskRequest()
        {
            Wait.Print("¡Perfecto! Soy capaz de responder cualquier pregunta desde... esa cosa, hasta... esa otra.");
            Wait.Print("1. ¿Cuál es el significado de la vida?");
            Wait.Print("2. ¿Cuál es tu nombre completo?");
            Wait.Print("3. ¿Qué vino primero, el huevo o la gallina?");
            Wait.Print("4. ¿Qué he hecho hasta ahora?");
            
            string input = Console.ReadLine();
            if (input == "4")
            {
                Wait.Print("Has hecho lo siguiente");
                var Count = 0;
                using(var reader = File.OpenText("Orders.txt"))
                {
                    while(true){
                        string line = reader.ReadLine();
                        if(line == null){
                            if(Count == 0){
                                Wait.Print("N-A-D-A");
                            }
                            break;
                            
                        }
                        Wait.Print(line);
                        Count++;
                    }
                }
                Wait.Print("Y creo que eso lo resumiría bastante bien.");
                Wait.Print("Volviendo al tema...");
            }
            else
            {
                Wait.Print("");
            }
            AddOrder();
        }

        public void AddOrder()
        {
            using( var writer = File.AppendText("Orders.txt") )
            {
                writer.WriteLine(OrderLog);
            }
        }
    }
}