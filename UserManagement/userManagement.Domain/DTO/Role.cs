namespace UserManagement.Domain.DTO
{
    public class Role
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ExpirationDate { get; set; } = DateTime.MaxValue;

        public string RolName { get; set; } = null!;

        public List<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();
    }
}
