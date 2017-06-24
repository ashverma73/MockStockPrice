using System;
using System.Linq;
using System.Web.Services;
using Microsoft.Practices.Unity;
using MockStockPrice.DataClient;
using MockStockPrice.DataModel;
using MockStockPrice.Hub;
namespace MockStockPrice
{
    /// <summary>
    /// On load, we create Unity Container as we are using Dependency Injection for Mocked Data Client, 
    /// This project can be enhanced to use Data from other resources as well.
    /// Also Microsoft SignalR Framework is used for real time data refresh. 
    /// Hub is used to interact with Client
    /// </summary>
    public partial class _Default : System.Web.UI.Page
    {
        protected IUnityContainer container;
        private static StockData _stockdata = null;
        private static MockPriceHub mph = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            container = new UnityContainer();
            
            ContainerBootStrapper.RegisterTypes(container);

            _stockdata = container.Resolve<IData>("MockedData").Data;
            mph = new MockPriceHub();
        }

        [WebMethod]
        public static Stock[] GetStockPrice(string ticker)
        {
            var stck = _stockdata.PricingData.Value.Where(p => p.Ticker == ticker);
            
                
                mph?.Reset();
                mph?.LoadTicker(stck.FirstOrDefault());
                mph?.StartTicking();
                return stck.ToArray();
        }


        [WebMethod]
        public static string[] GetTickerList(string keyword)
        {
            mph?.StopTicking();
            var lst=  _stockdata.PricingData.Value.Select(p => p.Ticker).Where(j => j.StartsWith(keyword,StringComparison.CurrentCultureIgnoreCase));
            if (lst.Any()) return lst.ToArray(); 
            return (new string[]  { ""});
          
        }
    }
}
