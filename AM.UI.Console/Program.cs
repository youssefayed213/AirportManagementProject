// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

Console.WriteLine("Hello, World!");

Plane plane = new Plane();
plane.Capacity = 100;
//Console.WriteLine(plane.Capacity);
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Boeing;

//Initialiseur d'objets
Plane plane2 = new Plane { Capacity = 300,
                            ManufactureDate = new DateTime(2024,02,06)  };

Console.WriteLine(plane2);

Passenger passenger = new Passenger
{
    FullName= new FullName { FirstName="test", LastName="test222"}
};

Console.WriteLine(passenger.FullName.CheckProfile("Test222", "Test") ); 

Staff s = new Staff();
Traveller tr = new Traveller();

s.PassengerType();

tr.PassengerType();
Console.WriteLine("**************FlightDates****************");
FlightMethode f = new FlightMethode();
f.Flights = TestData.listFlights;
f.GetFlightDates("Madrid");
Console.WriteLine("***************FlightFilters*****************");
//f.GetFlights("Destination", "Madrid");
foreach (var flight in f.GetFlights("EstimatedDuration", " 200"))
{
    Console.WriteLine(flight);
}

passenger.UpperFullName();
Console.WriteLine(passenger.UpperFullName());

//Initialise services
AMContext ctx = new AMContext();

IUnitOfWork uow = new UnitOfWork(ctx);

IServicePlane sp = new ServicePlane(uow);

IServiceFlight sf = new ServiceFlight(uow);

//Insert 2 planes
sp.Add(TestData.Airbusplane);
sp.Add(TestData.BoingPlane);

//Insert 2 flights
sf.Add(TestData.flight1);
sf.Add(TestData.flight2);

//Persistence
sf.Commit();// or sp.Commit()

Console.WriteLine("Add success");

//Display table flight content
foreach(Flight fl in sf.GetMany())
    Console.WriteLine("Date :"+fl.FlightDate+" Destination: "+fl.Destination+" Capacity of Plane: "+fl.Plane.Capacity);
