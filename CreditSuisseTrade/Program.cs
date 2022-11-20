using CreditSuisseTrade.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CreditSuisseTrade
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime referenceDate;
            string value;
            int amountOfTrades;

            Console.Clear();
            Console.WriteLine("Categorization of Negotiations Credit Suisse");
            Console.WriteLine("******************************");
            Console.WriteLine(" ");
            Console.Write("Reference date (mm/dd/yyyy): ");
            value = Console.ReadLine();

            if (!DateTime.TryParseExact(value, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out referenceDate))
            {
                throw new ArgumentException("Invalid date");
            }

            Console.Write("Number of trades in portfolio: ");
            value = Console.ReadLine();
            if (!int.TryParse(value, out amountOfTrades))
            {
                throw new ArgumentException("Invalid number");
            }
            List<Trade> lstTrades = new List<Trade>();
            for (int tradesNumber = 0; tradesNumber < amountOfTrades; tradesNumber++)
            {
                Console.Write($"Trade number {tradesNumber + 1} of {amountOfTrades}: ");
                value = Console.ReadLine();
                lstTrades.Add(new Trade(value));
            }

            foreach (var item in lstTrades)
            {
                Console.WriteLine(Category(item, referenceDate));
            }
        }
        private static string Category(Trade trade, DateTime date)
        {
            string tradeCategory;

            var expired = new Expired();
            tradeCategory = expired.RiskCategory(trade, date);
            if (tradeCategory != null)
                return tradeCategory;

            var highRisk = new HighRisk();
            tradeCategory = highRisk.RiskCategory(trade, date);
            if (tradeCategory != null)
                return tradeCategory;

            var mediumRisk = new MediumRisk();
            tradeCategory = mediumRisk.RiskCategory(trade, date);
            if (tradeCategory != null)
                return tradeCategory;

            else
                return Constants.NOTCATEGORIZED;
        }
    }
}
