using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockStockPrice;
using System;
using System.Collections.Generic;

using MockStockPrice.DataClient;
namespace MockStockPrice.Tests
{
    [TestClass()]
    public class _DefaultTests
    {
       
        private static StockData _stockdata =null;
        

       
        [TestMethod()]
        public void GetTickerListTest()
        {
            MockedDataClient mdc = new MockedDataClient(50);
            _stockdata = mdc.Data;
            Assert.IsNotNull(_stockdata);
            Assert.IsTrue(_stockdata.PricingData.Value.Count > 0);
        }
    }
}