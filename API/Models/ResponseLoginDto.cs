
namespace API.Models
{
    public class ResponseLoginDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string RefreshToken{ get; set; }
        public string Message { get; set; }
    }
}