// See https://aka.ms/new-console-template for more information

using OPP_Beispiel;
using System.Collections.Generic;

List<Vehicle> vehicles = new List<Vehicle>(); 

Car car = new Car()
{
    Acceleration = 100,
    DoorCount = 5,
    BreakSpeed =   500,
    Speed = 200,
};

Plane plane = new Plane()
{
    Acceleration = 500,
    DoorCount = 10,
    BreakSpeed = 200,
    Speed = 600,
    HasJetDrive = true
};

Mototcycle mototcycle = new Mototcycle()
{ Acceleration = 250, BreakSpeed = 25, DoorCount = 0, Speed = 350 };

Helicopter helicopter = new Helicopter()
{ Acceleration = 200, BreakSpeed = 200, DoorCount = 0, Speed = 150 };

vehicles.Add(car);
vehicles.Add(plane);
vehicles.Add(mototcycle);
vehicles.Add(helicopter);

Console.WriteLine("Welches Fahrzeug möchtest du fahren?");
var Userinput = Console.ReadLine();

foreach (Vehicle vehicle in vehicles)
{
    if (vehicle.GetType().Name == Userinput)
    {
        Console.WriteLine("Fahrzeug gefunden: " + Userinput);

        vehicle.LogInformation();

        if (Userinput == nameof(Car))
        {
            Car myCar = vehicle as Car;
            myCar.Move();
        }
        else if (Userinput == nameof(Plane))
        {
            Plane myPlane = vehicle as Plane;
            myPlane.Move();
        }
        else if (Userinput == nameof(Mototcycle))
        {
            Mototcycle myMoto = vehicle as Mototcycle;
            myMoto.Move();
        }
        else if (Userinput == nameof(Helicopter))
        {
            Helicopter myHelicopter = vehicle as Helicopter;
            myHelicopter.Move();
        }
        else
        {
            Console.WriteLine("Dieses Fahrzeug steht nicht bereit.");
        }

        break;
    }
}