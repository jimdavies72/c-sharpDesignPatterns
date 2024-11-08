// State Pattern allows an object to behave differently depending on its state

namespace MasterDesignPatterns.src.DesignPatterns
{
  public enum UserRoles
  {
    Reader,
    Editor,
    Admin
  }

  public interface IState
  {
    void Publish();
  }

  public class Document
  {

    public IState State { get; set; }
    public UserRoles CurrentUserRole { get; set; }

    public Document(UserRoles currentUserRole)
    {
      CurrentUserRole = currentUserRole;
      State = new Draft(this);
    }

    public void Publish()
    {
      State.Publish();
    }
  }

  public class Draft : IState
  {
    
    private Document document;

    public Draft(Document document)
    {
      this.document = document;
    }

    public void Publish()
    {
      document.State = new Moderation(document);
    }
  }

  public class Moderation : IState
  {
    
    private Document document;

    public Moderation(Document document)
    {
      this.document = document;
    }

    public void Publish()
    {
      if (document.CurrentUserRole == UserRoles.Admin)
      {
        document.State = new Published(document);
      }
    }
  }

  public class Published : IState
  {
    private Document document;

    public Published(Document document)
    {
      this.document = document;
    }

    public void Publish()
    {
      // do nothing if already in published state
    }
  }

} //ns