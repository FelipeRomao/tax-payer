using System;
using System.Collections.Generic;
using System.Globalization;
using Taxes.Entities;

namespace Taxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxes = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'i')
                {
                    Console.Write("Health expenditures:  ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    taxes.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else if (ch == 'c')
                {
                    Console.Write("Number of employees:  ");
                    int employees = int.Parse(Console.ReadLine());

                    taxes.Add(new Company(name, anualIncome, employees));

                }

            }

            Console.WriteLine("TAXES PAID:");
            double sumTaxes = 0.0;

            foreach (TaxPayer tax in taxes)
            {
                Console.WriteLine(tax.Name + " $" + tax.Tax().ToString("F2", CultureInfo.InvariantCulture));

                sumTaxes += tax.Tax();
            }

            Console.WriteLine("TOTAL TAXES: $" + sumTaxes.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
