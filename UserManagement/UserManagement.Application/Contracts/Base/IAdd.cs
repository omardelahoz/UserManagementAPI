using UserManagement.Domain.Entities.Base;

namespace UserManagement.Application.Contracts.Base
{
    public interface IAdd<T> where T : EntityBase
    {
        Task<T> Add(T entity);
    }
}
