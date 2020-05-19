using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle: Contracts.Gun
    {
        public Rifle(string name) : base(name,50,500)
        {

        }
        public override int Fire()
        {
            if (CanFire)
            {
                LoadedBulets -= 5;
                return 5;
            }
            else
            {
                if(TotalBullets >= 50)
                {
                    Reload();
                    LoadedBulets -= 5;
                    return 5;
                }
            }
            return 0;
        }
    }
}
