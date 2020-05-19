using SpaceStation.Core;
using SpaceStation.Core.Contracts;

namespace SpaceStation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}