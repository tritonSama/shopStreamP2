using shopModel;
namespace shopUI
{

    public class MainMenu : iMenu
    {
        public void Display()
        {
            Console.WriteLine("Hello, What will you be doing today?");
            Console.WriteLine("[1] - add a new customer");
            Console.WriteLine("[2] - seach customer");
            Console.WriteLine("[3] - Exit");
        }

        public string YourChoice()
        {
            // throw new NotImplementedException();

            string userInput = Console.ReadLine();

            if(userInput == "1")
            {
                return "AddCustomer";
            }
            else if (userInput == "2")
            {
                return "SearchCustomer";
            }
            else if (userInput == "3")
            {
                return "Exit";
            }
            else if (userInput == "0")
            {
                return "SecretMenu";
            }
            else
            {
                Console.WriteLine("Please input a valid response");
                return "MainMenu";
            }    
        }
    }
}