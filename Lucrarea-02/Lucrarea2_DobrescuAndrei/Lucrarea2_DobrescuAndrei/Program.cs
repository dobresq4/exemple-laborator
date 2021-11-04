using Lucrarea2_DobrescuAndrei.Domain;
using System;
using System.Collections.Generic;
using static Lucrarea2_DobrescuAndrei.Domain.ShoppingCarts;

namespace Lucrarea2_DobrescuAndrei
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listOfGrades = ReadListOfShoppingCarts().ToArray();
            PayShoppingCartCommand command = new(listOfGrades);
            PayShoppingCartWorkflow workflow = new PayShoppingCartWorkflow();
            var result = workflow.Execute(command, (productCode) => true);

            result.Match(
                    whenShoppingCartsPaidFailedEvent: @event =>
                    {
                        Console.WriteLine($"Pay failed: {@event.Reason}");
                        return @event;
                    },
                    whenShoppingCartsPaidScucceededEvent: @event =>
                    {
                        Console.WriteLine($"Pay succeeded.");
                        Console.WriteLine(@event.Csv);
                        return @event;
                    }
                );

            Console.WriteLine("Hello World!");
        }

        private static List<EmptyShoppingCart> ReadListOfShoppingCarts()
        {
            List<EmptyShoppingCart> listOfShoppingCarts = new();
            do
            {
                //read registration number and grade and create a list of greads

                var product_code = ReadValue("Codul produsului: ");
                if (string.IsNullOrEmpty(product_code))
                {
                    break;
                }

                var quantity = ReadValue("Cantitatea produsului comandat: ");
                if (string.IsNullOrEmpty(quantity))
                {
                    break;
                }

                var address = ReadValue("Adresa: ");
                if (string.IsNullOrEmpty(address))
                {
                    break;
                }

                var price = ReadValue("Pretul: ");
                if (string.IsNullOrEmpty(price))
                {
                    break;
                }

                listOfShoppingCarts.Add(new(product_code, quantity, address, price));
            } while (true);
            return listOfShoppingCarts;
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}