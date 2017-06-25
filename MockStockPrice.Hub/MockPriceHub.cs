
using Microsoft.AspNet.SignalR.Hubs;
using MockStockPrice.DataModel;
namespace MockStockPrice.Hub
{/// <summary>
/// Hub Class for Client Server SignalR communication
/// </summary>
    [HubName("stockPrice")]
    public class MockPriceHub : Microsoft.AspNet.SignalR.Hub
    {
        private readonly StockTicker _stockTicker;
        
        public MockPriceHub() :
                 this(StockTicker.Instance)
        {
          
        }
        public MockPriceHub(StockTicker stockTicker)
        {
            _stockTicker = stockTicker;
            
        }
        public void LoadTicker(Stock st)
        {

            _stockTicker.LoadDefaultStocks(st);
            
        }
        public void StartTicking()
        {
            
          
            _stockTicker.StartTicking();
        }

        public void Reset()
        {
            
            _stockTicker.Reset();
        }
        public void StopTicking()
        {
            _stockTicker.StopTicking();
        }
    }
}