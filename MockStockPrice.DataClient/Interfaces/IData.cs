using System;
using System.Collections.Generic;
using System.Text;


namespace MockStockPrice.DataClient
{
    public interface IData
    {
        StockData Data { get; set; }
    }
}
