using System.Text.Json;
using shopModel;

namespace shopDL
{
    
    public class CustomerRepository : iRepository<Customer>
    {
        private string _filepath = "../shopDL/Data/customer.json";


        public void Add(Customer p_cust)
        {
            List<Customer> listOfCust = GetAll();
            listOfCust.Add(p_cust);

            string jsonstring = JsonSerializer.Serialize(listOfCust, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath, jsonstring);
        }

    
        public List<Customer> GetAll()
        {
            string jsonString = File.ReadAllText(_filepath);
            List<Customer> listOfCustomer = JsonSerializer.Deserialize<List<Customer>>(jsonString);

            return listOfCustomer;
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer p_resource)
        {
            // show the current list of customers
            List<Customer> listOfCustomer = GetAll();

            foreach (Customer custObj in listOfCustomer)
            {
                if (custObj.name == p_resource.name)
                {
                    custObj.Items = p_resource.Items;
                }
            }

            // string jsonString = JsonSerializer.Serialize(listOfCustomer, new JsonSerializerOptions{WriteIndented = true});
            // File.WriteAllText(_filepath, jsonString);       
        }

      
    }
}