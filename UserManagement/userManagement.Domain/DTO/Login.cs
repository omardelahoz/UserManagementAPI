
namespace UserManagement.Domain.DTO
{
    public class Login
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Token { get; set; } = null!;
        public User? User { get; set; }

    }
}
