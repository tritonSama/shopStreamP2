using shopDL;
using shopModel;
namespace shopBL
{
    public class CustItemJoinBL : iCustItemJoinBL
    {
        private iRepository<CustomerItemJoin> _custItemRepo;
        public CustItemJoinBL(iRepository<CustomerItemJoin>p_custItemRepo)
        {
            _custItemRepo = p_custItemRepo;
        }
        public void AddItemQuant(int p_quant, int p_itemID, int p_custID)
        {
            CustomerItemJoin joinTable = new CustomerItemJoin();
            joinTable.itemID = p_itemID;
            joinTable.quant = p_quant;
            joinTable.custID = p_custID;

            _custItemRepo.Update(joinTable);
        }
    }

}
