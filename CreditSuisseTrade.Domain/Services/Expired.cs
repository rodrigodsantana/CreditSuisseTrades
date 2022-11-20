using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseTrade.Domain
{
    public class Expired : ITrade
    {
        public string RiskCategory(Trade trade, DateTime referenceDate)
        {
            return (referenceDate - trade.NextPaymentDate).Days > Constants.MAX_DAYS_TO_BE_EXPIRED ? Constants.EXPIRED : null;
        }
    }
}
