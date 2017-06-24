using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockStockPrice.DataModel
{
    public class Stock
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public double PxLast { get ; set; }
        public double CurrentPrice { get; set; }
        public double Chg { get; set; }

    }
}
