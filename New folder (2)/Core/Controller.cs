using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Mission;

namespace SpaceStation.Core
{
    class Controller : Contracts.IController
    {
        AstronautRepository AstronautRepository = new AstronautRepository();
        Mission mission = new Mission();
        public string AddAstronaut(string type, string astronautName)
        {
            
                if (type == "Biologist")
                {
                    Biologist biologist = new Biologist(astronautName);
                    AstronautRepository.Add(biologist);
                    return $"Successfully added {type}: {astronautName}!";
                }
                else if (type == "Geodesist")
                {
                    Geodesist geodesist = new Geodesist(astronautName);
                    AstronautRepository.Add(geodesist);
                    return $"Successfully added {type}: {astronautName}!";
                }
                else if (type == "Meteorologist")
                {
                    Meteorologist meteorologist = new Meteorologist(astronautName);
                    AstronautRepository.Add(meteorologist);
                    return $"Successfully added {type}: {astronautName}!";
                }
                else 
                {
                    return null;
                }
            
        }
        PlanetRepository PlanetRepository = new PlanetRepository();
        public string AddPlanet(string planetName, string[] items)
        {
            Planet planet = new Planet(planetName,items);
            PlanetRepository.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }
        private int Explored = 0;
        public string ExplorePlanet(string planetName)
        {
            ICollection<IAstronaut> CanGo = new List<IAstronaut>();
            for (int i = 0; i < AstronautRepository.Astronauts.Count; i++)
            {
                if (AstronautRepository.Astronauts[i].Oxygen >= 60)
                {
                    CanGo.Add(AstronautRepository.Astronauts[i]);
                }
            }
            if (CanGo.Count == 0 )
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            if (PlanetRepository.FindByName(planetName)!= null)
            {
                mission.Explore(PlanetRepository.FindByName(planetName), CanGo);
                Explored++;
                return $"Planet: {planetName} was explored! Exploration finished with {mission.DeadAftrerMIssion} dead astronauts!";
            }
            return null;
        }
        public string Report()
        {
            foreach (var item in AstronautRepository.Astronauts)
            {
                if (item.Bag.Items.Count != 0)
                {
                    return $"Astronauts info:\r\nName: {item.Name}\r\nOxygen: {item.Oxygen}\r\nBag items: {string.Join(", ",item.Bag.Items)}";
                }
                else
                {
                    return $"Astronauts info:\r\nName: {item.Name}\r\nOxygen: {item.Oxygen}\r\nBag items: none";
                }
            }
            return null;
        }

        public string RetireAstronaut(string astronautName)
        {
            if (AstronautRepository.FindByName(astronautName) != null)
            {
                AstronautRepository.Remove(AstronautRepository.FindByName(astronautName));
                return $"Astronaut {astronautName} was retired!";
            }
            else 
            {
                return $"Astronaut {astronautName} doesn't exists!";
            }
        }
    }
}
