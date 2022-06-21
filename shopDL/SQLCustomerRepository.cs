using Microsoft.Data.SqlClient;
using shopModel;
namespace shopDL
{
    public class SQLCustomerRepository : iRepository<Customer>
    {
         private string _connectionString; 
        public SQLCustomerRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }

        public void Add(Customer p_resource)
        {
            string SQLQuery = @"insert into Customer
            values( @custName, @custEmail, @custAddress, @custPhone, @custTotal)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);
          
                command.Parameters.AddWithValue("@custName", p_resource.name);
                command.Parameters.AddWithValue("@custEmail", p_resource.email);
                command.Parameters.AddWithValue("@custAddress", p_resource.address);
                command.Parameters.AddWithValue("@custPhone", p_resource.phone);
                command.Parameters.AddWithValue("@custTotal", p_resource.price);

                command.ExecuteNonQuery();
            }
        }

        public List<Customer> GetAll()
        {
            string SQLQuery = @"select * from Customer";
            List<Customer> listOfCustomer = new List<Customer>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                 con.Open();
                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader =  command.ExecuteReader();
                while( reader.Read())
                {
                    listOfCustomer.Add(new Customer()
                    {
                        custID = reader.GetInt32(0),
                        name = reader.GetString(1),
                        email = reader.GetString(2),
                        address = reader.GetString(3),
                        phone = reader.GetString(4),
                        price = reader.GetInt32(5)
                        
                    });

                }
                return listOfCustomer;
            }
        }

        public async Task<List<Customer>> GetAllAsync()
        {
             string SQLQuery = @"select * from Customer";
            List<Customer> listOfCustomer = new List<Customer>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader =  await command.ExecuteReaderAsync();
                while( await reader.ReadAsync())
                {
                    listOfCustomer.Add(new Customer()
                    {
                        custID = reader.GetInt32(0),
                        name = reader.GetString(1),
                        email = reader.GetString(2),
                        address = reader.GetString(3),
                        phone = reader.GetString(4),
                        price = reader.GetInt32(5)
                        
                    });

                }
                return listOfCustomer;
            }
        }

        public void Update(Customer p_resource)
        {
           string SQLquery = @"UPDATE Customer
            SET custName = @custName, custEmail = @custEmail, custAddress = @custAddress, custPhone = @custPhone, custTotal = @custTotal
			Where  custID = @custID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@custID", p_resource.custID);
                command.Parameters.AddWithValue("@custName", p_resource.name);
                command.Parameters.AddWithValue("@custEmail", p_resource.email);
                command.Parameters.AddWithValue("@custAddress", p_resource.address);
                command.Parameters.AddWithValue("@custPhone", p_resource.phone);
                command.Parameters.AddWithValue("@custTotal", p_resource.price);

                command.ExecuteNonQuery();
            }
        }

        List<Customer> iRepository<Customer>.GetAll()
        {
            throw new NotImplementedException();
        }

        private List<Item> GiveItemToCustomer(int p_custID)
        {
            string SQLquery = @" Select c.custName, i.itemName, ci.cartQuant, i.itemPrice, i.itemID from Customer c
                inner join Customer_Item ci on c.custID = ci.cust_ID
                inner join Item i on i.itemID = ci.itemID
                where c.custID = @custID";
            
            List<Item> listOfItem = new List<Item>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(SQLquery, con);
                command.Parameters.AddWithValue("@custID", p_custID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listOfItem.Add(new Item()
                    {
                        itemID = reader.GetInt32(1),
                        name = reader.GetString(2),
                        price = reader.GetInt32(3),
                        quant = reader.GetInt32(4)

                    });
                }
            }
            return listOfItem;
        }


        // public void Update(Customer p_resoure)
        // {
            
        //     string SQLquery = @"update customer
        //                         set " 
        //     using (SqlConnectioncon = new SqlConnection(_connectionString)
        // }
    }
}