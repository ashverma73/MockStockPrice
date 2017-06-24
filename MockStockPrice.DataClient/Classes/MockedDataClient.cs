using System;
using System.Collections.Generic;
using MockStockPrice.MockedData;
using MockStockPrice.DataModel;
namespace MockStockPrice.DataClient
{
    public class MockedDataClient : IData
    {
        int _numberofTickers;
        StockData data = null;
        public MockedDataClient(Int32 numberofTickers)
        {
            this._numberofTickers = numberofTickers;
        }
       

        public StockData Data
        {
            get
            {
               return data ?? GetStockData(); ;
            }
            set
            {
                data = value;
            }
        }

        private StockData GetStockData()
        {
            StockData stdata = new StockData();

            stdata.PricingData = new Lazy<List<Stock>>(() => MockData.GetPricingData() );
           
            return stdata;
        }
    }
}
