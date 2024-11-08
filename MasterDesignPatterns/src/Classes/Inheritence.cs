// When to use inheritance?
// when there is a clear 'is-a' relationship and 'has-a' relationship is not appropriate
// promote code reuse by inheriting properties and behaviours from existing classes
// Leverage polymorphism to allow objects of different subclasses to be treated the same

namespace MasterDesignPatterns.src.Classes
{
  public class Vehicle
  {
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Vehicle()
    {
      Brand = "Unknown";
      Model = "Unknown";
      Year = 0;
    }
    
    public void Start()
    {
      Console.WriteLine("Vehicle is starting...");
    }

    public void Stop()
    {
      Console.WriteLine("Vehicle is stopping...");
    }
  }

  public class Car : Vehicle
  // Car is a sub class of Vehicle
  // Car inherits all the properties of Vehicle
  {
    public int NumberOfDoors { get; set; }
    public float EngineSize { get; set; }

    public void Drive()
    {
      Console.WriteLine("Car is driving...");
    }
  }

  public class Bike : Vehicle
  // Bike is a sub class of Vehicle
  // Bike inherits all the properties of Vehicle
  {
    public int NumberOfGears { get; set; }

    public void Ride()
    {
      Console.WriteLine("Bike is riding...");
    }
  }
}
