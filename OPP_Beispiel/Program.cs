// See https://aka.ms/new-console-template for more information

using OPP_Beispiel;

Console.WriteLine("Hello, World!");

Car car = new Car()
{
    Acceleration = 100,
    DoorCount = 5,
    BreakSpeed =   500,
    Speed = 200,
};

car.LogInformation();

Plane plane = new Plane()
{
    Acceleration = 500,
    DoorCount = 10,
    BreakSpeed = 200,
    Speed = 600,
    HasJetDrive = true
};

plane.LogInformation();