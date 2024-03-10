using System;

namespace DenominationRoutine
{
    // This is a C# program that calculates the possible combinations of denominations for each payout amount for an ATM with three cartridges of different denominations: 10 EUR, 50 EUR, and 100 EUR.
    class Program
    {
        // Constants
        private const int PayoutCount = 9;
        private const int DenominationCount = 3;
        private static readonly int[] Denominations = { 10, 50, 100 };
        private static readonly int[] Payloads = { 30, 50, 60, 80, 140, 230, 370, 610, 980 };

        static void Main(string[] args)
        {
            // Calculate the possible combinations for each payout amount
            for (int i = 0; i < PayoutCount; i++)
            {
                CalculatePayoutCombinations(Payloads[i]);
            }
        }

        // This method calculates the possible combinations for a given payout amount
        public static void CalculatePayoutCombinations(int payout)
        {
            // Initialize an array to store the combination of denominations
            int[] combination = new int[DenominationCount];

            // Calculate the combination using the recursive method
            CalculateCombination(payout, Denominations, combination, 0);
        }

        // This method calculates the combination for a given payout amount and denominations
        private static void CalculateCombination(int payout, int[] denominations, int[] combination, int index)
        {
            // Base case: if the payout is 0, print the combination
            if (payout == 0)
            {
                PrintCombination(combination);
                return;
            }

            // Recursive case: if the payout is greater than 0, try to accommodate as many notes as possible for the highest denomination
            if (index < DenominationCount && payout >= denominations[index])
            {
                // Try the maximum number of notes for the current denomination
                for (int i = payout / denominations[index]; i >= 0; i--)
                {
                    // Set the current denomination to the combination
                    combination[index] = i;

                    // Recursively calculate the combination for the remaining payout and denominations
                    CalculateCombination(payout - i * denominations[index], denominations, combination, index + 1);
                }
            }
        }

        // This method prints the combination in a human-readable format
        private static void PrintCombination(int[] combination)
        {
            string result = "";

            for (int i = 0; i < combination.Length; i++)
            {
                if (combination[i] > 0)
                {
                    result += combination[i] + " x + " + Denominations[i] + " EUR ";
                }
            }

            Console.WriteLine(result);
        }
    }
}