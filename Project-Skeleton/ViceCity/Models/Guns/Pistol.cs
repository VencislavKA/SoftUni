using System;
using System.Collections.Generic;
using System.Text;


namespace ViceCity.Models.Guns
{
    public class Pistol : Contracts.Gun
    {
        public Pistol(string name) : base(name, 10, 100)
        {
            
        }
        public override int Fire()
        {
            if (CanFire)
            {
                LoadedBulets--;
                return 1;
            }
            else
            {
                if(TotalBullets >= 10)
                {
                    Reload();
                    LoadedBulets--;
                    return 1;
                }
            }
            return 0;
        }
    }
}
