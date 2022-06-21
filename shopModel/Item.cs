namespace shopModel
{
    public class Item 
    {
        public int itemID { get; set; }
        public string name { get; set; }
        private int _quant;
        public int quant 
        { 
            get { return _quant; } 
            set 
            {
                if ( value > 0 )
                {
                    _quant = value;
                }
                else
                {
                    Console.WriteLine("number of avialable items can not be less than 0");
                }
            }
        }
    
       public int price { get; set; }    

        public override string ToString()
        {
            return $"=====\nID: {itemID}nName: {name}\nPrice: {price}\nQuantity: {quant}\n========";
        }
    }        
}