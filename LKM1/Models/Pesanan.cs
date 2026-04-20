namespace LKM1.Models
{
    public class Pesanan
    {
        public int id { get; set; }
        public int pembeli_id { get; set; }   
        public int menu_id { get; set; }      
        public int quantity { get; set; }
        public string status { get; set; }
    }
}
