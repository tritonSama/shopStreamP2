using shopBL;
using shopModel;

namespace shopUI
{
    public class ViewItemOfCustomer : iMenu
    {
        private iCustItemJoinBL _custItemBL;
        public ViewItemOfCustomer(iCustItemJoinBL p_custItemBL)
        {
            _custItemBL = p_custItemBL;

        }
        public void Display()
        {
            Console.WriteLine("====Current item of customer====");
            foreach (Item itemObj in SearchCustomer.foundCustomer.Items)
            {
                Console.WriteLine(itemObj);
            }
            Console.WriteLine("press 1 to add item to customer");
            Console.WriteLine("press 0 to go back");
        }

        public string YourChoice()
        {
            string userInput = Console.ReadLine();

            if (userInput == "0")
            {
                return "SearchCustomer";
            }
            else if (userInput == "1")
            {
                Console.WriteLine(" Enter name of item you want to add");
                int itemID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How many do you want to purchase?");
                int quant = Convert.ToInt32(Console.ReadLine());

                _custItemBL.AddItemQuant(quant, itemID, SearchCustomer.foundCustomer.custID);

                Console.WriteLine("Done!");
                Console.ReadLine();

                return "searchCustomer";
            }
            else
            {
                return "MainMenu";
            }
        }
    }
}