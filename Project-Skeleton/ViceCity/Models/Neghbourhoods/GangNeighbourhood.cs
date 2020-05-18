using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : Contracts.INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while(mainPlayer.GunRepository.Models.Count != 0 && civilPlayers.Count != 0)
            {
                var c = civilPlayers as List<IPlayer>;
                var mainWepons = mainPlayer.GunRepository.Models as List<IGun>;
                for (int i = 0; i < mainWepons.Count; i++)
                {
                    var curentWepon = mainWepons[0];
                    var curentCivil = c[0];
                    while (curentWepon.CanFire && c.Count != 0)
                    {
                        curentCivil.TakeLifePoints(curentWepon.Fire());
                        if (!curentCivil.IsAlive)
                        {
                            c.RemoveAt(0);
                            civilPlayers.Remove(curentCivil);
                        }
                    }
                    if (!curentWepon.CanFire)
                    {
                        mainWepons.RemoveAt(0);
                        mainPlayer.GunRepository.Remove(mainPlayer.GunRepository.Find(mainWepons[0].Name));
                        return;
                    }
                }
            }
        }
    }
}
