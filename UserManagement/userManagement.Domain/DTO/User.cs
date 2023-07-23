namespace UserManagement.Domain.DTO
{
    public class User
    {
        public Guid? Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ExpirationDate { get; set; } = DateTime.MaxValue;

        public string Name { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsSuper { get; set; }

        public List<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();


    }
}
