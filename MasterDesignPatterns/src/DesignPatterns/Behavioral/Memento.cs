// Memento Pattern is used to return an object to a previous state
// such as undo a previous operation

namespace MasterDesignPatterns.src.DesignPatterns
{
  // Memento Pattern - Originator
  public class Editor
  {
    public string Title { get; set; }
    public string Content { get; set; }

    public Editor()
    {
      Title = "";
      Content = "";
    }

    public EditorState CreateState()
    {
      return new EditorState(Title, Content);
    }

    public void Restore(EditorState state)
    {
      Title = state.GetTitle();
      Content = state.GetContent();
    }
  }

  // Memento Pattern - Memento
  public class EditorState
  {
    // make private so once the editor state is created it canot be changed
    private readonly string title;
    private readonly string content;

    // state metadata
    private readonly DateTime stateCreatedAt;

    public EditorState(string title, string content)
    {
      this.title = title;
      this.content = content;
      stateCreatedAt = DateTime.Now;
    }

    public string GetTitle()
    {
      return title;
    }

    public string GetContent()
    {
      return content;
    }

    public DateTime GetStateCreatedAt()
    {
      return stateCreatedAt;
    }

    public string GetName()
    {
      return $"{title} - {content} - {stateCreatedAt}";
    }
  }

  // Memento Pattern - Caretaker
  public class History
  {
    private List<EditorState> states = new List<EditorState>();
    private Editor editor;

    public History(Editor editor)
    {
      this.editor = editor;
    }

    public void Backup()
    {
      states.Add(editor.CreateState());
    }

    public void Undo()
    {
      if (states.Count == 0)
      {
        return;
      }

      EditorState prevState = states.Last();
      states.Remove(prevState);
      editor.Restore(prevState);    
    }

    public void ShowHistory()
    {
      Console.WriteLine("\nHistory: List of Mementos:\n");
      foreach (var state in states)
      {
        Console.WriteLine(state.GetName());
      }
    }
  }
} //ns