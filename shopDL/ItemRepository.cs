using System.Text.Json;
using shopModel;

namespace shopDL 
{
    public class itemRepository : iRepository<Item>
    {
        private string _filepath = "../shopDL/Data/item.json";
        public void Add(Item p_resource)
        {
         throw new NotSupportedException();
        }

        public List<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        // public List<Item> GetAll()
        // {
        //     string jsonString = File.ReadAllText(_filepath);
        //     List<Item> listOfItem = JsonSerializer.Deserialize<List<Item>>(jsonString);

        //     return listOfItem;
        // }
        public void Update(Item p_resource)
        {
           throw new NotSupportedException();
        }        
    }
}