using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Beispiel
{
    internal class Helicopter : Plane
    {
        public override void Landing()
        {
            //base.Landing(); // Basis Methode aus Plane wird aufgerufen!

            Console.WriteLine("Der Helicopter sinkt langsam.");
        }
    }
}
