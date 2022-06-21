namespace shopUI
{
    public class SecretMenu : iMenu
    {
            
        public void Display()
        {
           
            Console.Clear();
            Console.WriteLine("Welcome back senpai!");
            Console.WriteLine("I missed you so much!");
            Console.WriteLine("How can I help you take over the world today?");
            Console.WriteLine("[1] add item");
            Console.WriteLine("[2] see items");
            Console.WriteLine("[3] remove item");
            Console.WriteLine("[0] MainMenu");
        
        }

        public string YourChoice()
        {
            string answer = Console.ReadLine();
            if (answer == "1") 
            {
                return "AddItem";
            }
            else if (answer == "2")
            {
                return "ItemList";
            }
            else if (answer == "3")
            {
                Console.WriteLine("Im not ready to do that just yet!");
                return "SecretMenu";
            }
            else if (answer == "0")
            {
                return "MainMenu";
            }
            else
            {
                Console.WriteLine("Silly senpai, Try again before i get angry!");
                return "SecretMenu";
            }

        }
    }















}