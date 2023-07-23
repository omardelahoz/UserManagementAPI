using UserManagement.Domain.Entities.Base;

namespace UserManagement.Domain.Entities
{
    public class Role : EntityBase
    {
        public string RolName { get; set; } = null!;

        public virtual ICollection<UsersRole> UsersRoles { get; set; } = new List<UsersRole>();
    }
}
