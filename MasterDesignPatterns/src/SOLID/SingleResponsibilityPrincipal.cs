// Single Responsibility Principle

// The single responsibility principle states that a class should have only one
// responsibility or purpose.

namespace MasterDesignPatterns.src.SOLID
{
  public class User
  {
    // single responsibility - user data management
    public string Username { get; set; }
    public string Email { get; set; }

    public User(string username, string email)
    {
      Username = username; 
      Email = email;
    }
  }

  public class UserService
  {
    // single responsibility - user registration (and other user business logic)
    public void Register(User user)
    {
      //Register logic here...

      // Send email
      EmailSender emailSender = new EmailSender();
      emailSender.SendEmail(user.Email, "Account created");
    }

  }

  public class EmailSender
  {
    // single responsibility - email sending
    public void SendEmail(string email, string message)
    {
      // Send email
      Console.WriteLine($"Sending email to {email}: {message}");
    }
  }

}