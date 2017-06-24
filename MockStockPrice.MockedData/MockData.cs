using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockStockPrice.DataModel;
using System.IO;
using Newtonsoft.Json;
using System.Web;
namespace MockStockPrice.MockedData
{
    public static class MockData
    {
        static List<Stock> _StockData = null;

        public static List<Stock> GetPricingData()
        {
            loadData();
           // List<Stock> tickers = new List<Stock>();
            return _StockData;
        }
        private static void loadData()
        {
            if (_StockData is null)
            {
                
                //var dirPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var dirPath = CurrentAssemblyDirectory();
                string json = File.ReadAllText(dirPath+ "\\tickerdata.json");
                _StockData = JsonConvert.DeserializeObject<List<Stock>>(json);
            }

        }
        static public string CurrentAssemblyDirectory()
        {
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
