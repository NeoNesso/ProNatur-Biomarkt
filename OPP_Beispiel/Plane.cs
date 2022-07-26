using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Beispiel
{
    internal class Plane : Vehicle, IVehicle  
    {
        public bool HasJetDrive { get; set; }

        public void Move()
        {
            Console.WriteLine("Das Flugzeug fliegt");
        }

        public virtual void Landing()
        {
            Console.WriteLine("Das Flugzeug landet");
        }
    }
}
