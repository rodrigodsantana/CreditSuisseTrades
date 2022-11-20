using System;
using System.Globalization;

namespace CreditSuisseTrade.Domain
{
    public class Trade
    {
        public double Value { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }
        public Trade(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Empty record found");
            }

            var values = value.Split(' ');

            if (values.Length < 3)
            {
                throw new ArgumentException($"Invalid format");
            }
            double _Value;
            if (!double.TryParse(values[0], out _Value))
            {
                throw new ArgumentException($"Invalid amount");
            }

            if (Convert.ToString(values[1]).ToUpper() != Constants.PRIVATESECTOR && Convert.ToString(values[1]).ToUpper() != Constants.PUBLICSECTOR)
            {
                throw new ArgumentException($"Invalid sector.");
            }
            DateTime dtNextPaymentDate;
            if (!DateTime.TryParseExact(values[2], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtNextPaymentDate))
            {
                throw new ArgumentException($"Invalid next payment");
            }

            Value = _Value;
            ClientSector = Convert.ToString(values[1]).ToUpper();
            NextPaymentDate = dtNextPaymentDate;
        }
        public static string Category(Trade trade, DateTime date)
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