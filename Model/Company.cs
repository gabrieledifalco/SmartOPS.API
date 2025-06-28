namespace SmartOPS.API.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PIVA { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
