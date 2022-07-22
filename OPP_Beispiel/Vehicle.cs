using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Beispiel
{
    abstract class Vehicle
    {
        public float Speed { get; set; }
        public float Acceleration { get; set; }
        public float BreakSpeed { get; set; }

        public int DoorCount { get; set; }

        public void LogInformation()
        {
            Console.WriteLine("Das Fahrzeug fährt mit " + Speed + " km/h.");
        }
    }
}
