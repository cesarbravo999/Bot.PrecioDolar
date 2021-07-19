using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.PrecioDolar.Clases
{
    public class DatosBloombergBE
    {
        public decimal percentChange1Day { get; set; }
        public decimal previousClosingPriceOneTradingDayAgo { get; set; }
        public decimal price { get; set; }
        public decimal openPrice { get; set; }
    }
}
