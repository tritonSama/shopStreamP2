using shopBL;
using shopModel;

public class AddItem2 : iMenu
{
    private Item itemObj = new Item();
    private iItemBL _itemBL;
    public AddItem2(iItemBL p_itemBL)
    {
        _itemBL = p_itemBL;
    }
    public void Display()
    {
        Console.WriteLine("Lets add some new stuff senpai!");
        Console.WriteLine("What are we selling?");
        itemObj.name = Console.ReadLine();
        Console.WriteLine("How much do you want someone to pay for it?");
        itemObj.price = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("How many of these are we adding to the shop?");
        itemObj.quant = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter 1 to add new item");
        Console.WriteLine("enter 0 to leave");

    }

    public string YourChoice()
    {
        string userInput = Console.ReadLine();
        if (userInput == "1")
        {
            _itemBL.AddItem(itemObj);
            return "SecretMenu";
        }
        else if (userInput == "0")
        {
            return "Exit";
        }
        else
        {
            Console.WriteLine("Enter a better answer senpai!");
            return "AddItem";
        }
    }
}