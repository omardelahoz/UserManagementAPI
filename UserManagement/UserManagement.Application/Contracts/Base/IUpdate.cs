using UserManagement.Domain.Entities.Base;

namespace UserManagement.Application.Contracts.Base
{
    public interface IUpdate<T> where T : EntityBase
    {
        Task<T> Update(T entity);
    }
}
