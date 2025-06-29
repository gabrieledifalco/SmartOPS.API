using SmartOPS.API.Model;

namespace SmartOPS.API.DTO.Response
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
