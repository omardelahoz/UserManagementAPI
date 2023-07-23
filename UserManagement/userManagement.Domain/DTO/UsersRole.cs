namespace UserManagement.Domain.DTO
{
    public class UsersRole
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ExpirationDate { get; set; } = DateTime.MaxValue;

        public Guid IdRol { get; set; }

        public Guid IdUser { get; set; }

        public User Role { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
