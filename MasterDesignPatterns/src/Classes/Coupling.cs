using MasterDesignPatterns.src.Interfaces;

namespace MasterDesignPatterns.src.Classes
{
  public class BadEmailSender
  {
    public void SendEmail(string message)
    {
      //Send email
      Console.WriteLine($"Sending email: {message}");
    }
  }

  public class BadOrder
  {
    public void PlaceOrder()
    {
      //Place order logic here...

      // tightly coupled to the BadEmailSender class
      // Order class is dependent upon the BadEmailSender class implementation
      BadEmailSender emailSender = new BadEmailSender();
      emailSender.SendEmail("Order placed");
    }
  }

  public class GoodEmailSender : INotificationService
  {
    public void SendNotification(string message)
    {
      //Send email
      Console.WriteLine($"Sending email: {message}");
    }
  }

  public class GoodTextSender : INotificationService
  {
    public void SendNotification(string message)
    {
      //Send text
      Console.WriteLine($"Sending text: {message}");
    }
  }

  public class GoodOrder
  // decoupled the GoodEmailSender class from the GoodOrder class
  {
    private readonly INotificationService notificationService;

    public GoodOrder(INotificationService notificationService)
    {
      this.notificationService = notificationService;
    }

    public void PlaceOrder(string message)
    {
      //Place order logic here...

      // loosely coupled to the Sender class
      notificationService.SendNotification($"{message}");
    }
  }
}