using UserManagement.Domain.Entities.Base;

namespace UserManagement.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsSuper { get; set; }

        public virtual ICollection<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();
    }
}
