using UserManagement.Domain.Entities.Base;

namespace UserManagement.Domain.Entities
{
    public class UsersRole : EntityBase
    {
        public Guid IdRol { get; set; }

        public Guid IdUser { get; set; }

        public virtual Role IdRolNavigation { get; set; } = null!;

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
