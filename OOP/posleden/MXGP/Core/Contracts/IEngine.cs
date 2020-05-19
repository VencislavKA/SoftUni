using System;
using System.Collections.Generic;
using System.Text;
using MXGP.IO;

namespace MXGP.Core.Contracts
{
    public class IEngine
    {
        ChampionshipController championshipController;

        public IEngine()
        {
            championshipController = new ChampionshipController();
        }

    }
}
