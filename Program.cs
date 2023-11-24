using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToshyroD {

    class VendingMachine
    {
        private static Dictionary<string, decimal> productPrices = new Dictionary<string, decimal>
    {
        { "Coca-Cola", 1.50m },
        { "Água", 1.00m },
        { "Pastelina", 0.30m }
    };

        private static Dictionary<decimal, int> coinInventory = new Dictionary<decimal, int>
    {
        { 0.01m, 10 },
        { 0.05m, 10 },
        { 0.10m, 10 },
        { 0.25m, 10 },
        { 0.50m, 10 },
        { 1.00m, 10 }
    };

        private static Dictionary<string, int> productInventory = new Dictionary<string, int>
    {
        { "Coca-Cola", 10 },
        { "Água", 10 },
        { "Pastelina", 10 }
    };

        private static decimal customerBalance = 0.00m;

        static void Main()
        {
            Console.WriteLine("Bem-vindo à Máquina!!");

            while (true)
            {
                Console.WriteLine("Digite 'CHANGE' para obter a alteração, o nome do produto para comprá-lo, ou você pode adicionar moedas:");

                string userInput = Console.ReadLine().Trim();

                if (userInput.Equals("CHANGE", StringComparison.OrdinalIgnoreCase))
                {
                    ProvideChange();
                }
                else if (productPrices.ContainsKey(userInput))
                {
                    ProcessProductPurchase(userInput);
                }
                else
                {
                    // Se não for 'CHANGE' ou um produto, assumiremos que é uma inserção de moeda
                    ProcessCoinInsertion(userInput);
                }
            }
        }

        private static void ProcessCoinInsertion(string coinInput)
        {
            string[] coinValues = coinInput.Split(' ');

            foreach (var coinValue in coinValues)
            {
                if (decimal.TryParse(coinValue, out decimal coin))
                {
                    if (coinInventory.ContainsKey(coin) && coinInventory[coin] > 0)
                    {
                        customerBalance += coin;
                        coinInventory[coin]--;

                        Console.WriteLine($"Moeda de {coin:C} inserida. Saldo atual de: {customerBalance:C}");
                    }
                    else
                    {
                        Console.WriteLine($"Moeda de {coin:C} não é válida ou não há mais disponível.");
                    }
                }
                else
                {
                    Console.WriteLine($"Valor inválido: {coinValue}");
                }
            }
        }
        

        private static void ProcessProductPurchase(string productName)
        {
            decimal productPrice = productPrices[productName];

            if (productInventory[productName] > 0 && customerBalance >= productPrice)
            {
                productInventory[productName]--;
                customerBalance -= productPrice;

                Console.WriteLine($"{productName} = {customerBalance:C}");

                if (customerBalance == 0)
                {
                    Console.WriteLine("Obrigado pela compra!");
                }
                else
                {
                    Console.WriteLine("Retire seu produto.");
                }
            }
            else if (productInventory[productName] == 0)
            {
                Console.WriteLine($"Lamento, {productName} está esgotado. Escolha outro produto.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente. Insira mais moedas para continuar ou escolha outro produto.");
            }
        }

        private static void ProvideChange()
        {
            List<decimal> changeCoins = new List<decimal>();
            decimal remainingChange = customerBalance;

            foreach (var coin in coinInventory.Keys)
            {
                int availableCoins = coinInventory[coin];

                while (remainingChange >= coin && availableCoins > 0)
                {
                    changeCoins.Add(coin);
                    remainingChange -= coin;
                    availableCoins--;
                }
            }

            if (remainingChange == 0)
            {
                foreach (var coin in changeCoins)
                {
                    Console.Write($"{coin:C} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para fornecer a alteração.");
            }

            ResetCustomerBalance();
        }

        private static void ResetCustomerBalance()
        {
            customerBalance = 0.00m;
        }
    }

}
