global using Serilog;
using Microsoft.Extensions.Configuration;
using shopUI;
using shopDL;
using shopBL;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt")
    .CreateLogger();

var configuration = new ConfigurationBuilder()  
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();


iMenu menu = new MainMenu();


bool repeat = true;

while (repeat)
{
    Console.Clear();
    menu.Display();
    string ans = menu.YourChoice();

    if (ans == "MainMenu")
    {
        Log.Information("User went to main menu");
        menu = new MainMenu();
    }
    else if (ans == "AddCustomer")
    {
        Log.Information("User adding a new customer");
        menu = new AddCustomer(new CustomerBL(new SQLCustomerRepository(configuration.GetConnectionString("Joshua Henry"))));
    }
    else if (ans == "SearchCustomer")
    {
        Log.Information("User searching for a customer");
        menu = new SearchCustomer(new CustomerBL(new SQLCustomerRepository(configuration.GetConnectionString("Joshua Henry"))));
    }
    else if (ans == "SelectItem")
    {
        Log.Information("User is selectiong a item");
        menu = new SelectItem(new ItemBL(new SQLItemRepository(configuration.GetConnectionString("Joshua Henry"))), new CustomerBL(new SQLCustomerRepository(configuration.GetConnectionString("Joshua Henry"))));
    }
    else if (ans == "ViewItemOfCustomer")
    {   
        Log.Information("User veiwing items of a customer");
        menu = new ViewItemOfCustomer(
            new CustItemJoinBL(
                new SQLCustItemJoinRepo(configuration.GetConnectionString("Joshua Henry"))));
    }
    else if (ans == "SecretMenu")
    {
        Log.Information("User going to admin menu(secret menu)");
        menu = new SecretMenu();
    }
    else if (ans == "AddItem")
    {
        Log.Information("User is adding a new item");
        menu = new AddItem2(new ItemBL(new SQLItemRepository(configuration.GetConnectionString("Joshua Henry"))));
    }
    else if (ans == "ItemList")
    {
        Log.Information("senpai is looking at the item list");
        menu = new ItemList(new ItemBL(new SQLItemRepository(configuration.GetConnectionString("Joshua Henry"))));
    }
    else if (ans == "Exit")
    {
        Log.Information("User is exiting");
        repeat = false;
    }

}


