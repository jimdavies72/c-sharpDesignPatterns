//Dependency Inversion Principle

// High-level modules should not depend on low-level modules. Both should depend on abstractions.

namespace MasterDesignPatterns.src.SOLID.D
{
  public interface IEngine
  {
    void Start();
  }

  public class Engine : IEngine
  {
    public void Start()
    {
      Console.WriteLine("Engine started");
    }
  }

  public class ElectiricEngine : IEngine
  {
    public void Start()
    {
      Console.WriteLine("Electric engine started");
    }
  }

  public class DIPCar
  {
    private IEngine engine;

    public DIPCar(IEngine engine)
    {

      this.engine = engine;
    }

    public void Start()
    {
      engine.Start();
      Console.WriteLine("Car started");
    }
  }
}