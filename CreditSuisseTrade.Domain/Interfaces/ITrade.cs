using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseTrade.Domain
{
    public interface ITrade
    {
        string RiskCategory(Trade trade, DateTime referenceDate);
    }
}
