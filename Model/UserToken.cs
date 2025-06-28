namespace SmartOPS.API.Model
{
    public class UserToken
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExiperesAt { get; set; }
        public bool IsRevoked { get; set; }

        public string? DeviseInfo { get; set; }
        public string? IpAddress { get; set; }
    }
}
