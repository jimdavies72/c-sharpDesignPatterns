// Command Pattern

// Command pattern encapsulates a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations. decouples sender from receiver.

namespace MasterDesignPatterns.src.DesignPatterns
{

  public interface ICommand
  {
    void Execute();
  }

  // The Receiver class
  public class Light
  { 

    public void TurnOnLight()
    {
      Console.WriteLine("Light turned on");
    }

    public void TurnOffLight()
    {
      Console.WriteLine("Light turned off");
    }

    public void Dim()
    {
      Console.WriteLine("Light dimmed");
    }
  }

  // The Sender class - Invoking a command
  public class RemoteControl
  {
    private ICommand command;

    public RemoteControl(ICommand command)  
    {
      this.command = command;
    }

    public void SetCommand(ICommand command)
    {
      this.command = command;
    }

    public void PressButton()
    {
      command.Execute();
    }
  }

  public class TurnOnCommand : ICommand
  {
    private Light light;

    public TurnOnCommand(Light light)
    {
      this.light = light;
    }

    public void Execute()
    {
        light.TurnOnLight();
    }
  }

  public class TurnOffCommand : ICommand
  {
    private Light light;

    public TurnOffCommand(Light light)
    {
      this.light = light;
    }

    public void Execute()
    {
      light.TurnOffLight();
    }
  }

  public class DimCommand : ICommand
  {
    private Light light;

    public DimCommand(Light light)
    {
      this.light = light;
    }

    public void Execute()
    {
      light.Dim();
    }
  }
}