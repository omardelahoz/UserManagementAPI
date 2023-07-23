namespace UserManagement.Domain.Entities.Base
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public EntityBase()
        {
            ExpirationDate = DateTime.MaxValue;
            IsActive = true;
        }
    }
}
