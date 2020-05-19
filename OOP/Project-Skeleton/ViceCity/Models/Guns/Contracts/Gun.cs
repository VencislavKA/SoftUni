using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns.Contracts
{
    public abstract class Gun : Contracts.IGun
    {
        public Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or a white space!");
            }
            Name = name;
            BulletsPerBarrel = bulletsPerBarrel;
            TotalBullets = totalBullets;
        }
        public string Name { get; }

        public int BulletsPerBarrel {
            get
            {
                return BulletsPerBarrel;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }
                BulletsPerBarrel = value;
                LoadedBulets = value;
            }
        }
        public int LoadedBulets {
            get;
            protected set;
        }
        public int TotalBullets { get { return TotalBullets; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }
                TotalBullets = value;
            }
        }

        public bool CanFire
        {
            get
            {
                if (this.TotalBullets == 0)
                {
                    return false;
                }
                return true;
            }
        }
        public virtual int Fire()
        {
            return 0;
        }
        
        public void Reload()
        {
            LoadedBulets = BulletsPerBarrel;
            TotalBullets -= BulletsPerBarrel;
        }
    }  
}
