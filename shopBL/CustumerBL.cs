using shopDL;
using shopModel;

namespace shopBL
{
    public class CustomerBL : iCustomerBL
    {
        private iRepository<Customer> _custRepo;
        public CustomerBL(iRepository<Customer> p_custRepo)
        {
            _custRepo = p_custRepo;
        }

        public void AddItemToCustomer(Customer p_customer)
        {
            _custRepo.Update(p_customer);
        }
   
        public void AddCustomer(Customer p_cust)
        {

            Customer foundCustomer = searchCustomerByName(p_cust.name);
            if (foundCustomer == null)
            {
                _custRepo.Add(p_cust);
            }
            else
            {
                throw new Exception("Customer already exists");
            }
        }


        public Customer searchCustomerByName(string p_custName)
        {
            List<Customer> currentListOfCust = _custRepo.GetAll();

            foreach (Customer custObj in currentListOfCust)
            {
                if (custObj.name == p_custName)
                {
                    return custObj;
                }
            }
            return null;
        }

        public object GiveItemToCustomer(Customer foundCustomer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomer()
        {
            return _custRepo.GetAll();
        }

        public Customer SearchCustomerByID(int p_id)
        {
            List<Customer> currentListOfCust = _custRepo.GetAll();

            foreach (Customer custObj in currentListOfCust)
            {
                if (custObj.custID == p_id)
                {
                    return custObj;
                }
            }
            return null;
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _custRepo.GetAllAsync();
        }
    }
}

