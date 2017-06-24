using System;
using System.Collections.Generic;
using System.Text;

namespace MockStockPrice.DataClient
{
    public class LiveDataClient : IData
    {
        public StockData Data { get ; set ; }
    }
}
