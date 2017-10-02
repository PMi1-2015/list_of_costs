namespace PurchaseList.Models
{
    public class User
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}