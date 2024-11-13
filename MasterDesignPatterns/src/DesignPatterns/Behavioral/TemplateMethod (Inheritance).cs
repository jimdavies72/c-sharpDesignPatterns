
namespace MasterDesignPatterns.src.DesignPatterns.Behavioral.TemplateMethod.Inheritance
{
  public abstract class Drink
  {
    public void Prepare()
    {
      // shared methods
      BoilWater();
      PourIntoCup();

      // unique methods
      Brew();
      AddCondiments();
    }

    private void BoilWater()
    {
      Console.WriteLine("Boiling Water for 4 minutes...");
    }

    private void PourIntoCup()
    {
      Console.WriteLine("Pouring boiled water into cup...");
    }

    // abstract methods MUST be implemented
    protected abstract void Brew();

    // virtual methods can optionally be implemented
    protected virtual void AddCondiments() {}
  }

  public class TeaDrink : Drink
  {
    protected override void Brew()
    {
      Console.WriteLine("Brewing Tea for 3 minutes...");
    }

    protected override void AddCondiments()
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
  }

  public class HotChocolateDrink : Drink
  {
    protected override void Brew()
    {
      Console.WriteLine("Brewing Hot Chocolate for 5 minutes...");
    }
  }
}