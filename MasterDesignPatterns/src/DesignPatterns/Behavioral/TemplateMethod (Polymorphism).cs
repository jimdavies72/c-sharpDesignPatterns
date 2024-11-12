// Template Method Pattern

// The Template Method Pattern defines the skeleton of an algorithm in a method, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.

namespace MasterDesignPatterns.src.DesignPatterns
{
  // using the Strategy Pattern
  public interface IDrink
  {
    void Prepare();
  }

  public class DrinksMaker
  {
    private IDrink drink;

    public DrinksMaker(IDrink drink)
    {
      this.drink = drink;
    }

    public void SetDrink(IDrink drink)
    {
      this.drink = drink;
    }

    public void MakeDrink()
    {
      // Shared Methods / Common Operations...
      BoilWater();
      PourIntoCup();
      
      // Unique Operations belonging to individual concrete classes
      drink.Prepare();
    }
    
    private void BoilWater()
    {
      Console.WriteLine("Boiling Water...");
    }

    private void PourIntoCup()
    {
      Console.WriteLine("Pouring boiled water into cup...");
    }
  }

  public class Tea : IDrink
  {
    private void Brew()
    {
      Console.WriteLine("Brewing Tea...");
    }

    private void AddCondiments()
    {
      if (CustomerWantsCondiments())
      {
        Console.WriteLine("Adding Lemon...");
      }
    }

    private bool CustomerWantsCondiments()
    {
      Console.WriteLine("Would you like Lemon Y/N?");
      string? input = Console.ReadLine();
      if (string.IsNullOrEmpty(input))
      {
        return false;
      }
      return input.ToLower().Equals("y");
    }

    public void Prepare()
    {
      Brew();
      AddCondiments();
    }
  }

  public class Coffee : IDrink
  {
    private void Brew()
    {
      Console.WriteLine("Brewing Coffee...");
    }

    private void AddCondiments()
    {
      if (CustomerWantsCondiments())
      {
        Console.WriteLine("Adding Cream...");
      }
    }

    private bool CustomerWantsCondiments()
    {
      Console.WriteLine("Would you like Cream Y/N?");
      string? input = Console.ReadLine();
      if (string.IsNullOrEmpty(input))
      {
        return false;
      }
      return input.ToLower().Equals("y");
    }

    public void Prepare()
    {
      Brew();
      AddCondiments();
    }
  }

  public class HotChocolate : IDrink
  {
    private void Brew()
    {
      Console.WriteLine("Brewing Choc...");
    }

    public void Prepare()
    {
      Brew();
    }
  }

}