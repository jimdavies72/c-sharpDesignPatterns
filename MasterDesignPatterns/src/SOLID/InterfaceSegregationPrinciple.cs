//Interface Segregation Principle

// Clients should not be forced to depend upon interfaces that they don't use.

namespace MasterDesignPatterns.src.SOLID.I
{
  // Bad example here:

  // public interface IShape
  // {
  //   double Area();
  //   double Volume();
  // }

  // public class Circle : IShape
  // {
  //   public double Radius { get; set; }

  //   public double Area()
  //   {
  //     return Math.PI * Math.Pow(Radius, 2);
  //   }

  //   // we are being forced to implement volume method as the interfce dictates this.
  //   // this violates the interface segregation principle
  //   public double Volume()
  //   {
  //     throw new NotImplementedException("Volume not applicable for 2d shapes");
  //   }
  // }

  // public class Sphere : IShape
  // {
  //   public double Radius { get; set; }
  
  //   public double Area()
  //   {
  //     return 4 * Math.PI * Math.Pow(Radius, 2);
  //   }

  //   public double Volume()
  //   {
  //     return (4 / 3) * Math.PI * Math.Pow(Radius, 3);
  //   }
  // }

  // Good example here:

  public interface IShape2D
  {
    double Area();
  }

  public interface IShape3D
  {
    double Area();
    double Volume();
  }

  public class Circle : IShape2D
  {
    public double Radius { get; set; }

    public double Area()
    {
      return Math.PI * Math.Pow(Radius, 2);
    }
  }

  public class Sphere : IShape3D
  {
    public double Radius { get; set; }

    public double Area()
    { 
      return 4 * Math.PI * Math.Pow(Radius, 2);
    } 

    public double Volume()
    {
      return (4 / 3) * Math.PI * Math.Pow(Radius, 3);
    }
  }

} //ns