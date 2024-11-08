using MasterDesignPatterns.src.Classes;
using MasterDesignPatterns.src.SOLID.L;
using MasterDesignPatterns.src.SOLID.I;
using MasterDesignPatterns.src.SOLID.D;
using MasterDesignPatterns.src.DesignPatterns;

namespace MasterDesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        //UsingClasses();
        //SOLIDPrinciples();

        // Design Patterns
        // Creational: Different ways of creating objects
        // Structural: Relationships between objects
        
        // Behavioral: Objects communicate with each other
        // MementoPattern();
        // StatePattern();
        //StrategyPattern();
        IteratorPattern();

        
    }

    static void UsingClasses()
    {
        //Encapsulation Example - contain all the data and methods within the class
        //BadBankAccount();
        //GoodBankAccount();

        //Abstraction - Reduce complexity by hiding unnecessary details
        //BadEmailService();
        //GoodEmailService();

        //Inheritence - Create a new class from an existing class
        //Vehicles();

        // Polymorphism - is the ability of an object to take on many forms and treat them the same
        //MoreVehicles();

        // Coupling - The degree of dependency between different classes
        //BadEmailSender();
        //GoodEmailSender();

        // Composition - create complex objects by combining simpler objects/components
        //CompositionCar();
    }

    static void SOLIDPrinciples()
    {
        // Liskov Substitution Principle
        //LiskovSubstitutionPrinciple();

        // Interface Segregation Principle
        //InterfaceSegregationPrinciple();

        // Dependency Inversion Principle
        //DependencyInversionPrinciple();
    }


    static void BadBankAccount()
    {
        //Encapsulation
        BadBankAccount badBankAccount = new BadBankAccount();

        badBankAccount.balance = 100;

        Console.WriteLine(badBankAccount.balance);
    }   

    static void GoodBankAccount()
    {
        //Encapsulation
        BankAccount BankAccount = new BankAccount(100);
        Console.WriteLine(BankAccount.GetBalance());

        BankAccount.Deposit(50);
        Console.WriteLine(BankAccount.GetBalance());

        BankAccount.Withdraw(75);
        Console.WriteLine(BankAccount.GetBalance());

    }    

    static void BadEmailService()
    {
        BadEmailService emailService = new BadEmailService();
        emailService.Connect();
        emailService.Authenticate();
        emailService.SendEmail();
        emailService.Disconnect();
    }

    static void GoodEmailService()
    {
       GoodEmailService emailService = new GoodEmailService();
       emailService.SendEmail();
       
    }

    static void Vehicles()
    {
        Car car = new Car();
        // shared properties/methods from Vehicle class
        car.Brand = "Ford";
        car.Model = "Mustang";
        car.Start();
        car.Stop();

        // properties and methods from Car sub-class
        car.NumberOfDoors = 2;
        car.EngineSize = 2.0F;
        car.Drive();


        Bike bike = new Bike();
        // shared properties/methods from Vehicle class
        bike.Brand = "Harley-Davidson";
        bike.Model = "Sportster";
        bike.Start();
        bike.Stop();

        // properties and methods from Bike sub-class
        bike.NumberOfGears = 6;
        bike.Ride();
    }

    static void MoreVehicles()
    // polymorphism - treating all different objects the same due to their related base class
    {
        List<Vehicle2> vehicles = new List<Vehicle2>(); 
        vehicles.Add(new Car2 {NumberOfDoors = 2, EngineSize = 2.0F});
        vehicles.Add(new MotorCycle {NumberOfGears = 6});

        foreach (var vehicle in vehicles)
        {
            vehicle.Start();
            vehicle.Stop();
        }
    }

    static void BadEmailSender()
    {
        BadOrder order = new BadOrder();
        order.PlaceOrder();
    }

    static void GoodEmailSender()
    {
        //GoodOrder order = new GoodOrder( new GoodEmailSender());
        //order.PlaceOrder("Order placed (Email)");

        GoodOrder order = new GoodOrder(new GoodTextSender());
        order.PlaceOrder("Order placed (Text)");
    }

    static void CompositionCar()
    {
        CompositionCar car = new CompositionCar();
        car.StartCar();

    }

    static void LiskovSubstitutionPrinciple()
    {
        // failes Liskov Substitution Principle
        // var rect = new Square();
        // rect.Width = 10;
        // rect.Height = 20;
        // Console.WriteLine($"Rectangle Area: {rect.Area}");

        // satisfies Liskov Substitution Principle as Square and Rectangle both inherit from Shape
        Shape rect = new Rectangle {Width = 10, Height = 20};
        Console.WriteLine($"Rectangle Area: {rect.Area}");

        Shape square = new Square {SideLength = 10};
        Console.WriteLine($"Square Area: {square.Area}");

    }

    static void InterfaceSegregationPrinciple()
    {
        var circle = new Circle {Radius = 5};
        Console.WriteLine($"Circle Area: {circle.Area()}");
        //Console.WriteLine($"Circle Volume: {circle.Volume()}");

        var sphere = new Sphere {Radius = 5};
        Console.WriteLine($"Sphere Area: {sphere.Area()}");
        Console.WriteLine($"Sphere Volume: {sphere.Volume()}");
    }

    static void DependencyInversionPrinciple()
    {
        // Dependency Injection - we are injecting the dependency into the class
        var car = new DIPCar(new MasterDesignPatterns.src.SOLID.D.ElectiricEngine());
        car.Start();
    }


    static void MementoPattern()
    {
        var editor = new Editor();
        var history = new History(editor);
        history.Backup();
        editor.Title = "Test";
        history.Backup();
        editor.Content = "Hello my name is James";
        history.Backup();
        editor.Title = "This is a new title";

        history.ShowHistory();
        
        Console.WriteLine($"\nTitle: {editor.Title}\nContent: {editor.Content}\n");
        history.Undo();
        Console.WriteLine($"\nTitle: {editor.Title}\nContent: {editor.Content}\n");
        history.Undo();
        Console.WriteLine($"\nTitle: {editor.Title}\nContent: {editor.Content}\n");
        history.Undo();
        Console.WriteLine($"\nTitle: {editor.Title}\nContent: {editor.Content}\n");

        history.ShowHistory();
    }
    static void StatePattern()
    {
        var document = new Document(UserRoles.Editor);
        Console.WriteLine(document.State);
        document.Publish();
        Console.WriteLine(document.State);
        document.CurrentUserRole = UserRoles.Admin;
        document.Publish();
        Console.WriteLine(document.State);
        
        // reset state manually also...
        document.State = new Draft(document);
        Console.WriteLine(document.State);
    }  
    static void StrategyPattern()
    {
        VideoStorge videoStorage = new VideoStorge(new MOVCompressor(), new BlackAndWhiteOverlay()); 
        videoStorage.Store("Video1");

        videoStorage.SetCompression(new MP4Compressor());
        videoStorage.SetOverlay(new NoneOverlay());
        videoStorage.Store("Video1");
    }
    static void IteratorPattern()
    {
        ShoppingList list = new ShoppingList();
        list.Push("Milk");
        list.Push("Bread");
        list.Push("Eggs");
    
        // this works because the class ShoppingList is a list.
        // changing it to a fixed length array would cause the loop below to fail
        // as Array type does not have a .Count property
        // for (int i=0; i < list.GetList().Count; i++)
        // {
        //     var item = list.GetList()[i];
        //     Console.WriteLine(item);
        // }

        var iterator = list.CreateIterator();
        while (iterator.HasNext())
        {
            var item = iterator.Current();
            Console.WriteLine(item);
            iterator.Next();
        }
        
    }

} //ns
