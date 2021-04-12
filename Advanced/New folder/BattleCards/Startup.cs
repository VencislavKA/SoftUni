namespace BattleCards
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using BattleCards.Controllers;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            routeTable.Add(new Route("/",HttpMethod.Get, new HomeController().Index));
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
        }
    }
}
