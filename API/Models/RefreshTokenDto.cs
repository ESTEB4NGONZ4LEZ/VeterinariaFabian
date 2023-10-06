
namespace API.Models
{
    public class RefreshTokenDto
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Token { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; }
        public bool IsRevoked { get; set; }
        public bool IsActive { get; set; }
    }
}