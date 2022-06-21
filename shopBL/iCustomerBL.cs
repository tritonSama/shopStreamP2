using shopModel;
namespace shopBL
{

    public interface iCustomerBL
    {
        void AddCustomer(Customer p_cust);
        Customer searchCustomerByName(string p_custName);
        void AddItemToCustomer(Customer p_customer);
        object GiveItemToCustomer(Customer foundCustomer);
        List<Customer> GetAllCustomer();
        Task<List<Customer>> GetAllCustomerAsync();
        Customer SearchCustomerByID(int p_id);
    }
}