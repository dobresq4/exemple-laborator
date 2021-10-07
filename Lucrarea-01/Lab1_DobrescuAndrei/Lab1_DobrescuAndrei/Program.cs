using Lab1_DobrescuAndrei.Domain;
using System;
using System.Collections.Generic;
using static Lab1_DobrescuAndrei.Domain.ShoppingCart;


namespace Lab1_DobrescuAndrei.Domain
{
    class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listOfShoppingCarts = ReadListOfShoppingCarts().ToArray();
            EmptyShoppingCarts emptyShoppingCarts = new(listOfShoppingCarts);
            IShoppingCarts result = ValidateShoppingCarts(emptyShoppingCarts);
            result.Match(
                whenEmptyShoppingCarts: emptyResult => emptyShoppingCarts,
                whenUnvalidatedShoppingCarts: unvalidatedResult => unvalidatedResult,
                whenPaidShoppingCarts: paidResult => paidResult,
                whenValidatedShoppingCarts: validatedResult => PayShoppingCart(validatedResult)
            );

            Console.WriteLine("Session over, get back to your shopping menu!");
        }

        private static List<EmptyShoppingCart> ReadListOfShoppingCarts()
        {
            List<EmptyShoppingCart> listOfShoppingCarts = new();
            do
            {
                var quantity_ = ReadValue("Product quantity: ");
                if (string.IsNullOrEmpty(quantity_))
                {
                    break;
                }

                var productCode_ = ReadValue("Product code: ");
                if (string.IsNullOrEmpty(productCode_))
                {
                    break;
                }

                var address_ = ReadValue("Address: ");
                if (string.IsNullOrEmpty(address_))
                {
                    break;
                }

                listOfShoppingCarts.Add(new(quantity_, productCode_, address_));
            } while (true);
            return listOfShoppingCarts;
        }

        private static IShoppingCarts ValidateShoppingCarts(EmptyShoppingCarts emptyShoppingCarts) =>
            random.Next(100) > 50 ?
            new UnvalidatedShoppingCarts(new List<UnvalidatedShoppingCart>(), "Random errror")
            : new ValidatedShoppingCarts(new List<ValidatedShoppingCart>());

        private static IShoppingCarts PayShoppingCart(ValidatedShoppingCarts validExamGrades) =>
            new PaidShoppingCarts(new List<ValidatedShoppingCart>(), DateTime.Now);

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
