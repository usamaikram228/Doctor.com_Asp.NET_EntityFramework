namespace Project.Models
{
    public class Cart
    {
        public List<Medicine> list { get; set; }
        public int bill { get; set; }
        public Cart()
        {
            list = new List<Medicine>();
            bill = 0;
        }
    }
}
