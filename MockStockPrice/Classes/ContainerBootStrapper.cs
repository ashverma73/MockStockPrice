using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using MockStockPrice.DataClient;
namespace MockStockPrice
{
    class ContainerBootStrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IData, MockedDataClient>("MockedData",
                                            new TransientLifetimeManager(),
                                            new InjectionConstructor(30));

            container.RegisterType<IData, LiveDataClient>("DbData",
                                            new TransientLifetimeManager(),
                                            new InjectionConstructor());
        }
    }
}