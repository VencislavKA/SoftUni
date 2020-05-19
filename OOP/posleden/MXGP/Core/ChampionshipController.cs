using MXGP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Repositories;
using System.Linq;


namespace MXGP.Core
{
    public class ChampionshipController : Contracts.IChampionshipController
    {
        private MotorcycleRepository motorcycleRepository;
        private RaceRepository raceRepository;
        private RiderRepository riderRepository;

        public ChampionshipController()
        {
            motorcycleRepository = new MotorcycleRepository();
            raceRepository = new RaceRepository();
            riderRepository = new RiderRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            if (motorcycleRepository.GetByName(motorcycleModel) == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }
            var r = riderRepository.GetByName(riderName);
            var m = motorcycleRepository.GetByName(motorcycleModel);
            r.AddMotorcycle(m);
            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }
        public string AddRiderToRace(string raceName, string riderName)
        {
            if (raceRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (riderRepository.GetByName(riderName) == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            var r = raceRepository.GetByName(raceName);
            var rider = riderRepository.GetByName(riderName);
            r.AddRider(rider);
            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (motorcycleRepository.GetByName(model) != null)
            {
                if(type == null)
                {
                    if (type == "Power")
                    {
                        PowerMotorcycle powerMotorcycle = new PowerMotorcycle(model, horsePower);
                        motorcycleRepository.Add(powerMotorcycle);
                        return $"PowerMotorcycle {model} is created.";
                    }
                    else if (type == "Speed")
                    {
                        PowerMotorcycle powerMotorcycle = new PowerMotorcycle(model, horsePower);
                        motorcycleRepository.Add(powerMotorcycle);
                        return $"SpeedMotorcycle {model} is created.";
                    }
                }
            }
            throw new ArgumentException($"Motorcycle {model} is already created.");
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetByName(name) == null)
            {
                Race race = new Race();
                race.Name = name;
                race.Laps = laps;
                raceRepository.Add(race);
                return $"Race {name} is created.";
            }
            throw new InvalidOperationException($"Race {name} is already created.");
        }

        public string CreateRider(string riderName)
        {
            if (riderRepository.GetByName(riderName) == null)
            {
                Rider rider = new Rider(riderName);
                riderRepository.Add(rider);
                return$"Rider {riderName} is created.";
            }
            throw new ArgumentException($"Rider {riderName} is already created.");
        }
        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (raceRepository.GetByName(raceName).Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            return null;
        }
    }
}
