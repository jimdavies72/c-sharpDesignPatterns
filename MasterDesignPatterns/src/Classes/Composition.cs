// Creating complex objects by combining simpler objects/components. 'has a' relationship

// When to use composition?
// flexibility - create a class from smaller classes
// when there is no clear 'is-a' relationship and 'has-a' relationship is more appropriate
// to avoid the limitations of inheritance 

namespace MasterDesignPatterns.src.Classes
{

  public class CompositionCar
  {
    private Engine engine = new Engine();
    private Wheels wheels = new Wheels();
    private Chassis chassis = new Chassis();
    private Seats seats = new Seats();

    public void StartCar()
    {
      engine.Start();
      wheels.Rotate();
      chassis.Support();
      seats.Sit();
      Console.WriteLine("Car started");
    }

  }

  public class Chassis
  {
    public void Support()
    {
      Console.WriteLine("Chassis supports vehicle");
    }
  }

  public class Engine
  {
    public void Start()
    {
      Console.WriteLine("Engine started");
    }
  }

  public class Seats
  {
    public void Sit()
    {
      Console.WriteLine("Seats are sat");
    }
  }

  public class Wheels
  {
    public void Rotate()
    {
      Console.WriteLine("Wheels are rotated");
    }
  }
}