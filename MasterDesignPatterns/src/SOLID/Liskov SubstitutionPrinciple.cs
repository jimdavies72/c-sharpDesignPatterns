// Liskov Substitution Principle

// Objects of a superclass should be replaceable with objects of its subclasses without
// breaking the application.

namespace MasterDesignPatterns.src.SOLID.L
{
  public abstract class Shape
  {
    public abstract double Area { get; }

  }

  public class Rectangle : Shape
  {
    public virtual double Width { get; set; }
    public virtual double Height { get; set; }

    public override double Area => Width * Height;
  }

  public class Square : Shape // not inheriting from Rectangle
  {
    public double SideLength { get; set; }

    public override double Area => Math.Pow(SideLength, 2);
  }


} //ns

