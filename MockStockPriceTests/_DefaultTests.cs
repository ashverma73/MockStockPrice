using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockStockPrice;
using System.Linq;
using System.Collections.Generic;

using MockStockPrice.DataClient;
namespace MockStockPrice.Tests
{
    [TestClass()]
    public class _DefaultTests
    {

        private static StockData _stockdata = null;
        MockedDataClient mdc = new MockedDataClient(50);


        [TestMethod()]
        public void GetTickerListTest()
        {
            
            _stockdata = mdc.Data;
            Assert.IsNotNull(_stockdata);
            Assert.IsTrue(_stockdata.PricingData.Value.Count > 0);
        }

        [TestMethod()]
        public void GetStockPriceTest()
        {
            Assert.IsTrue(mdc.Data.PricingData.Value.Where(p => p.Ticker == "GOOG").Count() > 0);
        }
    }
}