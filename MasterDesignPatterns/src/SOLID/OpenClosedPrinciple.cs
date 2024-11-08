//Open/Closed Principle

// The open/closed principle states that a class should be open for extension
// but closed for modification.

namespace MasterDesignPatterns.src.SOLID
{
  public enum ShapeType
  {
    Circle,
    Rectangle
  }

  // does not follow the open/closed principle
  // public class Shape
  // {
  //   public ShapeType Type { get; set; }
  //   public double Radius { get; set; }
  //   public double Length { get; set; }
  //   public double Width { get; set; }

  //   public double CalculateArea()
  //   {
  //     switch (Type)
  //     {
  //       case ShapeType.Circle:
  //         return Math.PI * Math.Pow(Radius, 2);
  //       case ShapeType.Rectangle:
  //         return Length * Width;
  //       default:
  //         throw new InvalidOperationException($"Invalid shape type: {Type}");
  //     }
  //   }
  // }

  
  // follows the open/closed principle
  public abstract class Shape
  {
    public abstract double CalculateArea();
  }

  public class Circle : Shape
  {
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
  }

  public class Rectangle : Shape
  {
    public double Length { get; set; }
    public double Width { get; set; }

    public override double CalculateArea()
    {
        return Length * Width;
    }
  }
} //ns