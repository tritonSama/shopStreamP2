using shopBL;
using shopModel;

public class AddCustomer : iMenu
{
    private Customer custObj = new Customer();

    private iCustomerBL _custBL;
    public AddCustomer(iCustomerBL p_custBL)
    {
        _custBL = p_custBL;
    }
    
    public void Display()
    {
        Console.WriteLine("Now starting the new customer process.");
        Console.WriteLine("What is the new customer's name? ");
        custObj.name = Console.ReadLine();
        Console.WriteLine("What is the new customer's phone number? ");
        custObj.phone = Console.ReadLine();
        Console.WriteLine("What is the email address? ");
        custObj.email = Console.ReadLine();
        Console.WriteLine("What is the street address?");
        custObj.address = Console.ReadLine();
        Console.WriteLine("[1] - Add the new customer");
        Console.WriteLine("[0] - Return");
        
    }

    public string YourChoice()
    {
       string userInput = Console.ReadLine();
       if (userInput == "1")
       {
           _custBL.AddCustomer(custObj);
           return "MainMenu";
       }
       else if (userInput == "0")
       {
           return "MainMenu"; 
       }
       else
       {
           Console.WriteLine("Please enter a correct response");
           return "AddCustomer";
       }

    }
}