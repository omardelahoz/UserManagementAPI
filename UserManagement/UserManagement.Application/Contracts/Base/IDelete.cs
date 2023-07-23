using UserManagement.Domain.Entities.Base;

namespace UserManagement.Application.Contracts.Base
{
    public interface IDelete<T> where T : EntityBase
    {
        Task<bool> Delete(Guid id);
    }
}
