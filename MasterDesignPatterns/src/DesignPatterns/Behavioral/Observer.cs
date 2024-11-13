// Observer Pattern - AKA Publish and Subscribe pattern

// Useful when you are interested in the state of an object and want to get notified whenever there is any change. It invovles an object known as the 'subject', maintaining a list of its dependent objects called observers and notifying them automatically whenever the state of the subject changes.

namespace MasterDesignPatterns.src.DesignPatterns
{
  // Interface
  public interface IObserver
  {
    void Update();
  }

  // Subject abstract class
  public abstract class Subject 
  {
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
      observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
      observers.Remove(observer);
    }

    public void NotifyObservers()
    {
      foreach (var observer in observers)
      {
        observer.Update();
      }
    }
  }

  // Subject concrete class
  public class DataSource : Subject
  {
    private List<int> values = new List<int>();
    
    public List<int> GetValues()
    {
      return values;
    }

    public void SetValues(List<int> values)
    {
      this.values = values;

      NotifyObservers();
    }
  }

  // Observer -dependent object
  public class Sheet2 : IObserver
  {
    private int total;
    private DataSource dataSource;

    public Sheet2(DataSource dataSource)
    {
      this.dataSource = dataSource;
    }

    public int GetTotal()
    {
      return total;
    }

    public void Update()
    {
      total = CalculateTotal(dataSource.GetValues());
    }

    public int CalculateTotal(List<int> values)
    {
      var sum = 0;
      foreach (var value in values)
      {
        sum += value;
      }
      
      Console.WriteLine($"Total: {sum}");
      return sum;
    }
  }

  // Observer - dependent object
  public class BarChart : IObserver
  {
    private DataSource dataSource;

    public BarChart(DataSource dataSource)
    {
      this.dataSource = dataSource;
    }
    
    public void Update()
    {
      Console.WriteLine("\nBar Chart:\n");
      foreach (var value in dataSource.GetValues())
      {
        Console.WriteLine($"{new string('*', value)} ({value})");
      }
      Console.WriteLine();
    }

  }
}