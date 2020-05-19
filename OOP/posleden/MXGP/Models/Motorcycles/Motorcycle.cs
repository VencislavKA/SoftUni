using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : Contracts.IMotorcycle
    {
        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            Model = model;
            CubicCentimeters = cubicCentimeters;
        }

        private string models;
        private int horsePower;
        public string Model { 
            get => models; 
            private set 
            { 
                if(string.IsNullOrWhiteSpace(value) && value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");////???????????????????????? dont know is this value or what
                }
            } 
        }
        public int HorsePower {
            get => horsePower; 
            private set 
            {
                if(this.Model == "Power")
                {
                    if (value >= 70 && value <= 100)
                    {
                        horsePower = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid horse power: {value}.");
                    }
                }
                else if(Model == "Speed")
                {
                    if (value >= 50 && value <= 69)
                    {
                        horsePower = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid horse power: {value}.");
                    }
                }
            }
        }
        
        public double CubicCentimeters { get;private set; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
