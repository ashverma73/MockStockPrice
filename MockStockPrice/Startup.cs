
using Owin;




namespace MockStockPrice
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Microsoft.AspNet.SignalR.GlobalHost.Configuration.DefaultMessageBufferSize = 50;
            app.MapSignalR();
        }
    }
}