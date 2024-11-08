namespace MasterDesignPatterns.src.Classes
{
  public class BadEmailService
  {
    public void SendEmail()
    {
      //Send email
      Console.WriteLine("Sending email...");
    }

    public void Connect()
    {
      //Connect to server
      Console.WriteLine("Connecting to email server...");
    }

    public void Authenticate()
    {
      //Authenticate
      Console.WriteLine("Authenticating...");
    }

    public void Disconnect()
    {
      //Disconnect from server
      Console.WriteLine("Disconnecting from email server...");
    }
  }

  public class GoodEmailService
  {
    public void SendEmail()
    {
      //Send email using Abstraction
      Connect();
      Authenticate();
      Console.WriteLine("Sending email...");
      Disconnect();
    }

    private void Connect()
    {
      //Connect to server
      Console.WriteLine("Connecting to email server...");
    }

    private void Authenticate()
    {
      //Authenticate
      Console.WriteLine("Authenticating...");
    }

    private void Disconnect()
    {
      //Disconnect from server
      Console.WriteLine("Disconnecting from email server...");
    }
  }
}