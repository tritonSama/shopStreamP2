using shopBL;
using shopModel;

namespace shopUI
{
    public class SelectItem : iMenu
    {
        private iItemBL _itemBL;
        private iCustomerBL _custBL;
        public SelectItem(iItemBL p_itemBL, iCustomerBL p_custBL)
        {
            _itemBL = p_itemBL;
            _custBL = p_custBL;
        }
        public void Display()
        {
            List<Item> ListOfItem = _itemBL.GetAllItem();
            foreach (Item itemObj in ListOfItem)
            {
                Console.WriteLine(itemObj.quant + " " + itemObj.name+"s are avaliable costing $" + itemObj.price +" each");          
            }
        }

        public string YourChoice()
        {
            Console.WriteLine("What item would you like to select?");
            Console.WriteLine("===================================");
            string userInput = Console.ReadLine();

            Item foundItem = _itemBL.searchItemByName(userInput);
            
            if (foundItem != null)
            {
                SearchCustomer.foundCustomer.Items.Add(foundItem);
                _custBL.AddItemToCustomer(SearchCustomer.foundCustomer);
                Console.WriteLine("Done!");
            }
            else
            {
                Console.WriteLine("Item was not found, please try again and enter exact name (case sensitive)");
                Console.ReadLine();
                return "SelectItem";
            }

            Console.ReadLine();
            return "MainMenu";
        }
    }
}