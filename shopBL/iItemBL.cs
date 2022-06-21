using shopModel;
namespace shopBL
{
    public interface iItemBL
    {
        List<Item> GetAllItem();
        Item searchItemByName(string p_itemName);
        void AddItem(Item p_item);
        Item searchItemById(string p_itemName);
    }
}