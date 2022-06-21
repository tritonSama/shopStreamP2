using shopBL;
using shopModel;

public class SearchCustomer : iMenu
{
    public static Customer foundCustomer;
    private iCustomerBL _custBL;
    public SearchCustomer(iCustomerBL p_custBL)
    {
        _custBL = p_custBL;
    }

    public void Display()
    {
        Console.WriteLine("How would you like to find a customer?");
        Console.WriteLine("[1] - Search by name");
        // Console.WriteLine("[2] - Search by phone number");
        Console.WriteLine("[0] - Go back");
    }

    public string YourChoice()
    {
        string userInput = Console.ReadLine();
        if (userInput == "3")
        {
            return "MainMenu";
        }
        else if (userInput == "1")
        {
            Console.WriteLine("What is the name of the customer?");
            string custName = Console.ReadLine();

            foundCustomer = _custBL.searchCustomerByName(custName);

            if (foundCustomer == null)
            {
                Console.WriteLine("This customer is not registered");
            }
            else
            {
                Console.WriteLine(foundCustomer.ToString());

                Console.WriteLine("Want to add items to cart?");
                Console.WriteLine("enter Y for yes or N for no");
                Console.WriteLine("Use capital letters when entering answer");
                string addCustChoice = Console.ReadLine();
                if (addCustChoice == "Y")
                {
                    return "SelectItem";
                }
                else if  (addCustChoice == "N")
                {
                    return "searchCustomer";
                }
                else
                {
                    return "PLease enter proper answer";
                }
            }
            Console.ReadLine();
            return "SearchCustomer";
        }
        else if (userInput == "2")
        {
            Console.ReadLine();
            return "MainMenu";
        }
        else if (userInput == "0")
        {
            return "MainMenu";
        }
        else
        {
            Console.WriteLine("Please input a valid response");
            return "SearchCustomer";
        }
    }
}