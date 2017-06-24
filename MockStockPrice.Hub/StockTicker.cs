using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNet.SignalR.Hubs;
using MockStockPrice.DataModel;
namespace MockStockPrice.Hub
{
    public class StockTicker
    {
        // Singleton instance
        private readonly static Lazy<StockTicker> _instance = new Lazy<StockTicker>(
            () => new StockTicker(Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<MockPriceHub>().Clients));

        private readonly object _marketStateLock = new object();
        private readonly object _updateStockPricesLock = new object();

        private readonly ConcurrentDictionary<string, Stock> _stocks = new ConcurrentDictionary<string, Stock>();

        // Stock can go up or down by a percentage of this factor on each change
        private readonly double _rangePercent = 0.02;

        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(5000);
      //  private readonly Random _updateOrNotRandom = new Random();

        private Timer _timer;
        private volatile bool _updatingStockPrices;
        

        private StockTicker(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
           
        }
       

        public static StockTicker Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return _stocks.Values;
        }

        public void StartTicking()
        {
            lock (_marketStateLock)
            {
               
                    _timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);
            }
        }
        public void StopTicking()
        {
            lock (_marketStateLock)
            {
                
                _timer?.Dispose();
            }
        }


        public void Reset()
        {
            lock (_marketStateLock)
            {
               
                BroadcastMarketReset();
            }
        }
      
        public void LoadDefaultStocks(Stock st)
        {
            _stocks.Clear();
            _stocks.TryAdd(st.Ticker, st);
           
        }

        private void UpdateStockPrices(object state)
        {
            // This function must be re-entrant as it's running as a timer interval handler
            lock (_updateStockPricesLock)
            {
                if (!_updatingStockPrices)
                {
                    _updatingStockPrices = true;

                    foreach (var stock in _stocks.Values)
                    {
                        if (TryUpdateStockPrice(stock))
                        {
                            BroadcastStockPrice(stock);
                        }
                    }

                    _updatingStockPrices = false;
                }
            }
        }

        private bool TryUpdateStockPrice(Stock stock)
        {
            if(stock.CurrentPrice == 0) stock.CurrentPrice = stock.PxLast;

            // Update the stock price by a random factor of the range percent
            var random = new Random();
            double percentChange = random.NextDouble() * _rangePercent;
            var pos = random.NextDouble() > 0.5;
            double change = Math.Round(stock.CurrentPrice * percentChange, 2);
            change = pos ? change : -change;
            stock.CurrentPrice = Math.Round(stock.CurrentPrice + change, 2);
            stock.Chg = Math.Round(stock.CurrentPrice - stock.PxLast,2);
            return true;
        }

       
        private void BroadcastMarketReset()
        {
            Clients.All.marketReset();
        }

        private void BroadcastStockPrice(Stock stock)
        {
            Clients.All.updateStockPrice(stock);
        }
    }
}