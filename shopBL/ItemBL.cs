using shopDL;
using shopModel;

namespace shopBL
{
    public class ItemBL : iItemBL
    {
        // Edpendency Injection
        private iRepository<Item> _itemRepo;
        public ItemBL(iRepository<Item> p_itemRepo)
        {
            _itemRepo = p_itemRepo;
        }

        public void AddItem(Item p_item)
        {
            Item foundItem = searchItemByName(p_item.name);
            if (foundItem == null)
            {
                _itemRepo.Add(p_item);
            }
            else
            {
                throw new Exception("Item already exists");
            }
        }

        public List<Item> GetAllItem()
        {
            return _itemRepo.GetAll();
        }

        public Item searchItemById(int p_itemID)
        {
           return _itemRepo.GetAll().First(item => item.itemID == p_itemID);
        }

        public Item searchItemById(string p_itemName)
        {
            throw new NotImplementedException();
        }

        public Item searchItemByName(string p_itemName)
        {
            List<Item> currentListOfItem = _itemRepo.GetAll();

            foreach (Item itemObj in currentListOfItem)
            {
                if (itemObj.name == p_itemName)
                {
                    return itemObj;
                }
            }
            // will return null if item can not be found
            return null;
        }

    }
}