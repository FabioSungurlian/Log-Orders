using System;
using System.Collections.Generic;
using System.Threading;

namespace LogOrders
{
    class BuyManager
    {
        private Order order;
        public BuyManager(Order order)
        {
            this.order = order;
        }

        public void BuyRequest()
        {
            Wait.Print("¿Qué es lo que quieres comprar?");
            Wait.Print("1. Una pizza");
            Wait.Print("2. Un spaguetti religioso");
            Wait.Print("3. Un unicornio");
            Wait.Print("4. Tu alma");

            var input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    order.AddOrderInfo("pizza, cantidad: ");
                    BuyPizza();
                    break;
                case "2":
                    order.AddOrderInfo("Spagetti religioso, cantidad: ");
                    BuySpagetti();
                    break;
                case "3":
                    Wait.Print("ya te dije que no había, por favor elije otra cosa.");
                    BuyRequest();
                    break;
                case "4":
                    Wait.Print("Se nos acabaron ayer, lo siento mucho.");
                    Wait.Print("Elije otra cosa.");
                    BuyRequest();
                    break;
                default:
                    Wait.Print("Tengo la intuición de que lo que ingresaste difiere en algun sentido con las opciones que te hemos dado.");
                    Wait.Print("Por favor elije de nuevo.");
                    BuyRequest();
                    break;
            }
            
        }
        public void BuyPizza()
        {
            Wait.Print("Excelente elección, para completar su compra digame:");
            Wait.Print("¿Cuantas pizzas desea?");
            specifyQuantity();
        }

        public void BuySpagetti()
        {
            Wait.Print("Excelente elección, para completar su compra digame:");
            Wait.Print("¿Cuantos spagettis religiosos desea?");
            specifyQuantity();
        }
        private void specifyQuantity()
        {
            var line = Console.ReadLine();
            try 
            {
                var num = int.Parse(line);
                if(num == 0)
                {
                    throw new ArgumentException("");
                }

                var price = num * 2345.6;
                order.AddOrderInfo($"{line} costo: {price:N2}");
                
                Wait.Print($"Tu compra va a costar {price} dolares");
                bool buyPizzas = AskToContinue();

                if(buyPizzas == true)
                {
                    
                    order.AddOrder();

                    Wait.Print("Que disfrute de su compra.");
                }
                else
                {
                    Wait.Print("usted se lo pierde");
                }

            } 
            catch(Exception ex)
            {
                Wait.Print("No te entendi bien, asegurate de que sea un número sin espacios ni decimales.");
                Wait.Print("Recuerde que no se pueden comprar 0 items, pero puede cancelar el pedido.");
                specifyQuantity();
            }
        }
        private bool AskToContinue()
        {
            Wait.Print("¿Estas seguro que deseas continuar?");
            Wait.Print("1. Si");
            Wait.Print("2. No");
            var answer = Console.ReadLine();
            switch(answer)
            {
                case "1":
                    return true;
                case "2":
                    return false;
                default:
                    Wait.Print("por favor escriba su respuesta de nuevo sin espacios extra");
                    return AskToContinue();
            }
        }
    }
}