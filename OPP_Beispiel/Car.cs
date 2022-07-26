using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Beispiel
{
    internal class Car : Vehicle, IVehicle
    {
        public void Move()
        {
            Console.WriteLine("Das Auto fährt!"); 
        }
    }
}
