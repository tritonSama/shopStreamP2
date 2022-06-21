using shopBL;
using shopModel;

namespace shopUI
{
    public class ItemList : iMenu
    {
         private iItemBL _itemBL;
        public ItemList(iItemBL p_itemBL)
        {
            _itemBL = p_itemBL;
        }


        public void Display()
        {
            List<Item> ListOfItem = _itemBL.GetAllItem();
            foreach (Item itemObj in ListOfItem)
            {
                Console.WriteLine(itemObj.quant + " " + itemObj.name+"s are avaliable costing $" + itemObj.price +" each");         
            }
            Console.WriteLine("You want to add or remove something?");
            Console.WriteLine("1 to add item");
            Console.WriteLine("2 to go back to main menu");
            Console.WriteLine("3 to remove item");
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
                return "MainMenu";
            }
            else if (answer == "3")
            {
                Console.WriteLine("That feature is not ready yet Senpai!");
                return "ItemList";
            }
            else
            {
                Console.WriteLine("Try again senpai! Not a good answer");
                return "ItemList";
                
            }
        }
    }
}