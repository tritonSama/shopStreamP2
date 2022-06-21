using Microsoft.Data.SqlClient;
using shopModel;

namespace shopDL
{
    public class SQLCustItemJoinRepo : iRepository<CustomerItemJoin>
    {
        private string _connectionString;
        public SQLCustItemJoinRepo(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }

        public void Add(CustomerItemJoin p_resource)
        {
            throw new NotImplementedException();
        }

        public List<CustomerItemJoin> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomerItemJoin>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerItemJoin p_resource)
        {
            string SQLquery = @"update Customer_Item
                                set quant = @cartQuant
                                where custID = @custID and itemID = @itemID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@cartQuant", p_resource.quant);
                command.Parameters.AddWithValue("@custID", p_resource.custID);
                command.Parameters.AddWithValue("@itemID", p_resource.itemID);

                command.ExecuteNonQuery();
            }
        }
    }
}