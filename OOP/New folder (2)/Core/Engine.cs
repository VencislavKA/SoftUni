
namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.IO;
    using SpaceStation.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SpaceStation.Core;
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private Controller controller = new Controller();
        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
        }
        public void Run()
        {
            
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                //try
                //{
                    if (input[0] == "AddAstronaut")
                    {
                        List<string> tupes = new List<string> { "Biologist", "Geodesist", "Meteorologist" };
                        if (tupes.Contains(input[1]))
                        {
                            writer.WriteLine(controller.AddAstronaut(input[1], input[2]));
                        }
                        else
                        {
                            throw new InvalidOperationException("Astronaut type doesn't exists!");
                        }
                    }

                    else if (input[0] == "AddPlanet")
                    {
                        List<string> vs = new List<string>();
                        for (int i = 0; i < input.Length; i++)
                        {
                            if(i != 0 && i != 1)
                            {
                                vs.Add(input[i]);
                            }
                        }
                        writer.Write(controller.AddPlanet(input[1],vs.ToArray()));
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        writer.Write(controller.RetireAstronaut(input[1]));
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        writer.Write(controller.ExplorePlanet(input[1]));
                    }
                    else if (input[0] == "Report")
                    {
                        writer.Write(controller.Report());
                    }
                //}
                //catch (Exception ex)
                //{
                //    writer.WriteLine(ex.Message);
                //}
            }
        }
    }
}
