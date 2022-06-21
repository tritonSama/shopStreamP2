using Microsoft.Data.SqlClient;
using shopModel;
namespace shopDL
{
    public class SQLItemRepository : iRepository<Item>
    {
         private string _connectionString; 
        public SQLItemRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }

        public void Add(Item p_resource)
        {
            string SQLQuery = @"insert into Item
            values (@itemName, @itemPrice, @itemQuant)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);
                
                command.Parameters.AddWithValue("@itemName", p_resource.name);
                command.Parameters.AddWithValue("@itemPrice", p_resource.price);
                command.Parameters.AddWithValue("@itemQuant", p_resource.quant);
               

                command.ExecuteNonQuery();
            }
        }

        public List<Item> GetAll()
        {
            string SQLQuery = @"select * from Item";
            List<Item> listOfItem = new List<Item>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    listOfItem.Add(new Item()
                    {
                        itemID = reader.GetInt32(0),
                        name = reader.GetString(1),
                        price = reader.GetInt32(2),
                        quant = reader.GetInt32(3),
                     
                        
                    });

                }
                return listOfItem;  
            }
        }

        public Task<List<Item>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        // private List<Item> GiveItemToCustomer(int p_custID)
        // {
        //     string SQLquery = @"select c.custName, i.itemName, ci.cartQuant, i.itemPrice, i.itemID from Customer c
        //         inner join Customer_Item ci on c.custID = ci.cust_ID
        //         inner join Item i on i.itemID = ci.itemID
        //         where c.custID = @custName";

        //     List<Item> listOfItem = new List<Item>();
        //     using (SqlConnection con = new SqlConnection(_connectionString))
        //     {
        //         con.Open();
        //         SqlCommand command = new SqlCommand(SQLquery, con);
        //         command.Parameters.AddWithValue("@custID", p_custID);
        //         SqlDataReader reader = command.ExecuteReader();
        //         while (reader.Read())
        //         {
        //             listOfItem.Add(new Item()
        //             {
        //                 itemID = reader.GetInt32(1),
        //                 name = reader.GetString(2),
        //                 price = reader.GetInt32(3),
        //                 quant = reader.GetInt32(4)

        //             });
        //         }
        //     }
        //     return listOfItem;
        // }


        public void Update(Item p_resoure)
        {
            throw new NotImplementedException();
        }

       
    }
}