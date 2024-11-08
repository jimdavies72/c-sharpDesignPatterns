//Iterator Pattern

// The Iterator Pattern provides a way of iterating over an object without exposing its underlying representation. Changing the internals of an object should not affect its consumers.

namespace MasterDesignPatterns.src.DesignPatterns
{
  // Iterator Pattern
  public interface IIterator<T>
  {
    void Next();
    bool HasNext();
    T Current();
  }

  public class ShoppingList
  {
    private List<string> list = new List<string>();

    // nested class - because this class is ONLY concerned with the shopping list class.
    // nesting it stops the class being called from other parts of the codebase.
    private class ListItterator : IIterator<string>
    {
      private ShoppingList list;
      private int index;

      public ListItterator(ShoppingList list)
      {
        this.list = list;
        index = 0;
      }

      public string Current()
      {
        return list.list[index];
      }

      public bool HasNext()
      {
        return index < list.list.Count;
      }

      public void Next()
      {
        index++;
      }
    }

    //methods
    public IIterator<string> CreateIterator()
    {
      return new ListItterator(this);
    }

    public void Push(string itemName)
    {
      list.Add(itemName);
    }

    public string Pop()
    {
      var last = list.Last();
      list.Remove(last);
      return last;
    }

    public List<string> GetList()
    {
      return list;
    }
  }
} // ns
  