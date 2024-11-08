namespace MasterDesignPatterns.src.Classes
{
  public class Vehicle2
  {
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Vehicle2()
    {
      Brand = "Unknown";
      Model = "Unknown";
      Year = 0;
    }

    // note the virtual keyword which means the method can be overwritten
    public virtual void Start()
    {
      Console.WriteLine("Vehicle is starting...");
    }

    public virtual void Stop()
    {
      Console.WriteLine("Vehicle is stopping...");
    }
  }

  public class Car2 : Vehicle2
  {
    public int NumberOfDoors { get; set; }
    public float EngineSize { get; set; }

    public override void Start()
    {
      Console.WriteLine("Car is starting...");
    }

    public override void Stop()
    {
      Console.WriteLine("Car is stopping...");
    }
  }

  public class MotorCycle : Vehicle2
  {
    public int NumberOfGears { get; set; }

    public override void Start()
    {
      Console.WriteLine("MotorCycle is starting...");
    }

    public override void Stop()
    {
      Console.WriteLine("MotorCycle is stopping...");
    }
  }
}