using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseTrade.Domain
{
    public class MediumRisk : ITrade
    {
        public string RiskCategory(Trade trade, DateTime referenceDate)
        {
            return trade.Value > Constants.MIN_VALUE && trade.ClientSector.Equals(Constants.PUBLICSECTOR) ? Constants.MEDIUMRISK : null;
        }
    }
}
