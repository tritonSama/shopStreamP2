using System.ComponentModel.DataAnnotations;
namespace shopModel
{
    public class Customer
    {
        private int _custID;
        public int custID
        {
            get { return _custID; }
            set
            {
                if ( value > 0 )
                {
                    _custID = value;
                }
                else
                {
                    throw new ValidationException("Customer customer ID must be greater than 0");
                }
            }
        }
  
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int price { get; set; }
        public List<Item> Items { get; set; }
        
        public Customer()
        {
            custID = 7;
            name = "Sama";
            Items = new List<Item>();
        }

        public override string ToString()
        {
            return $"===Customer Info===\nName: {name}\nTotal: {price}\n =============";
        }
    }
}