using System;
using System.Collections.Generic;
using System.Text;
using MockStockPrice.DataModel;
namespace MockStockPrice.DataClient
{
    public class StockData
    {
       public Lazy<List<Stock>> PricingData { get; set; }
    }
}
