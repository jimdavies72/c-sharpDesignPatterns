// Command Pattern - Undo


namespace MasterDesignPatterns.src.DesignPatterns
{
  // public interface ICommand
  // {
  //   void Execute();
  // }

  public interface IUndoableCommand : ICommand
  {
    void Unexecute();
  }

  public class UndoHistory
  {
    private List<IUndoableCommand> commands = new List<IUndoableCommand>();

    public void Push(IUndoableCommand command)
    {
      commands.Add(command);
    }

    public IUndoableCommand Pop()
    {
      var last = commands.Last();
      commands.Remove(last);
      return last;
    }

    public int Size()
    {
      return commands.Count;
    }
  }

  public class HtmlDocument
  {
    public string Content { get; set; }

    public HtmlDocument()
    {
      Content = "";
    }

    public void MakeItalic()
    {
      Content = $"<i>{Content}</i>";
    }
  }

  public class ItalicCommand : IUndoableCommand
  {
    private HtmlDocument document;
    private UndoHistory history = new UndoHistory();
    private string previousContent = "";

    public ItalicCommand(HtmlDocument document, UndoHistory history)
    {
      this.document = document;
      this.history = history;
    }

    public void Execute()
    {
      previousContent = document.Content;
      document.MakeItalic(); // delegating work to document Business Object
      history.Push(this);
    }

    public void Unexecute()
    {
      document.Content = previousContent;
    }
  }

  public class UndoCommand : ICommand
  {
    private UndoHistory history;

    public UndoCommand(UndoHistory history)
    {
      this.history = history;
    }

    public void Execute()
    {
      if (history.Size() > 0)
      {
        var lastCommand = history.Pop();
        lastCommand.Unexecute();
      }
    }
  }
}