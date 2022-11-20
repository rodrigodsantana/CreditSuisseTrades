using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisseTrade.Domain
{
    public static class Constants
    {
        public const double MIN_VALUE = 1_000_000;
        public const int MAX_DAYS_TO_BE_EXPIRED = 30;

        public const string HIGHRISK = "HIGHRISK";
        public const string MEDIUMRISK = "MEDIUMRISK";
        public const string EXPIRED = "EXPIRED";

        public const string PUBLICSECTOR = "PUBLIC";
        public const string PRIVATESECTOR = "PRIVATE";
        public const string NOTCATEGORIZED = "NOT CATEGORIZED";
        public const string PEP = "PEP (Pessoa Politicamente Exposta)";

    }
}
