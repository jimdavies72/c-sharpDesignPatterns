// Mediator Pattern

// The Mediator Pattern defines an object (the Mediator) that describes how a set of objects interact with each other. The Mediator Pattern lets you reduce the coupling between objects.

namespace MasterDesignPatterns.src.DesignPatterns.Behavioral
{
  // Mediator Class - everytime a component changes its state it will call the DialogBox
  public abstract class DialogBox
  {
    public abstract void Changed(UIControl uIControl);
    
  }

  public abstract class UIControl
  {
    protected DialogBox owner;

    public UIControl(DialogBox owner)
    {
      this.owner = owner;
    }
  }

  public class ListBox : UIControl
  {
    private string selectedValue = "";

    public ListBox(DialogBox owner) : base(owner)
    {
    }

    public string GetSelectedValue()
    {
      return selectedValue;
    }

    public void SetSelectedValue(string value)
    {
      selectedValue = value;
      owner.Changed(this);
    }
  }

  public class TextBox : UIControl
  {
    private string text = "";

    public TextBox(DialogBox owner) : base(owner)
    {
    }

    public string GetText()
    {
      return text;
    }

    public void SetText(string value)
    {
      text = value;
      owner.Changed(this);
    }
  }

  public class Button : UIControl
  {
    private bool Enabled;

    public Button(DialogBox owner) : base(owner)
    {
    }

    public bool isEnabled()
    {
      return Enabled;
    }

    public void SetEnabled(bool value)
    {
      Enabled = value;
      owner.Changed(this);
    }
  }

  // Concrete Mediator
  public class PostsDialogBox : DialogBox
  {
    //fields for UI Components
    private ListBox postsListBox;
    private TextBox titleTextBox;
    private Button saveButton;

    public PostsDialogBox()
    {
      postsListBox = new ListBox(this);
      titleTextBox = new TextBox(this);
      saveButton = new Button(this);
      saveButton.SetEnabled(false);
    }

    public void SimulateUserInteraction(){
      postsListBox.SetSelectedValue("Post 2");
      titleTextBox.SetText("");
      Console.WriteLine($"Title: {titleTextBox.GetText()}");
      Console.WriteLine($"Save Button Enabled: {saveButton.isEnabled()}");
    }

    public override void Changed(UIControl uIControl)
    {
      // Should be replaced by the Observer Pattern to remove lengthy if-else statements
      if(uIControl == postsListBox)
      {
        handlePostChanged();
      } else if (uIControl == titleTextBox)
      {
        handleTitleChanged();
      }
    }

    private void handlePostChanged()
    {
      titleTextBox.SetText(postsListBox.GetSelectedValue());
      saveButton.SetEnabled(true);
    }

    private void handleTitleChanged()
    {
      bool isTitleEmpty = string.IsNullOrEmpty(titleTextBox.GetText());
      saveButton.SetEnabled(!isTitleEmpty);
    }
  }
} //ns